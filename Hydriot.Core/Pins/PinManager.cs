using Hydriot.Core.Pins.Gpio;
using Hydriot.Core.Pins.Pwm;
using Microsoft.IoT.Lightning.Providers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Devices.Pwm;

namespace Hydriot.Core.Pins
{
    public class PinManager : IPinManager
    {
        #region Methods

        public static async Task<PinManager> CreateAsync()
        {
            if (!LightningProvider.IsLightningEnabled)
            {
                throw new NotSupportedException("Controller needs Ligtning provider");
            }

            var gpioController = await GpioController.GetDefaultAsync();
            var pwmController = await PwmController.GetDefaultAsync();

            var pwmProvider = LightningPwmProvider.GetPwmProvider();

            var list = (await PwmController.GetControllersAsync(pwmProvider));
            var length = list.Count;
            var controller = list[1];
            controller.SetDesiredFrequency(50);
            return new PinManager(gpioController, controller);
        }

        public T CreatePin<T>(int pinNumber) where T : class
        {
            return CreatePin<T>(pinNumber, null);
        }

        public T CreatePin<T>(int pinNumber, params object[] list) where T : class
        {
            IPin pin = null;
            switch (typeof(T).Name)
            {
                case "IGpioInputPin":
                    pin = new GpioInputPin(_gpioController.OpenPin(pinNumber), list);
                    break;

                case "IGpioOutputPin":
                    pin = new GpioOutputPin(_gpioController.OpenPin(pinNumber), list);
                    break;

                case "IPwmPin":
                    pin = new PwmPinBase(_pwmController.OpenPin(pinNumber), pinNumber, 50);
                    break;
#if false
                case "ISwitchButton":
                    pin = new SwitchButton(_gpioController.OpenPin(pinNumber), list);
                    break;

                case "IServo":
                    pin = new Servo(_pwmController.OpenPin(pinNumber), pinNumber, 50, list);
                    break;
#endif

                default:
                    throw new ArgumentException($"Type {typeof(T)} not supported");
            }

            _pinList.Add(pin);

            return (T)pin;
        }

        public async Task InitializeAsync()
        {
            foreach (var pin in _pinList)
            {
                await pin.InitializeAsync();
            }
        }

        #endregion Methods

        #region Properties/Fields

        private readonly GpioController _gpioController;
        private readonly PwmController _pwmController;

        private List<IPin> _pinList;

        #endregion Properties/Fields

        #region ctor

        private PinManager(GpioController gpio, PwmController pwm)
        {
            _pinList = new List<IPin>();

            _gpioController = gpio;
            _pwmController = pwm;
        }

        #endregion ctor
    }
}