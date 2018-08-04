using System;
using Windows.Devices.Gpio;

namespace Hydriot.Core
{
    public class PinController : IPinController
    {
        #region Methods

        public static PinController Create()
        {
            return new PinController();
        }

        public T CreatePin<T>(int number) where T : class
        {
            IPin pin = null;
            switch( typeof(T).Name)
            {
                case "IInputPin":
                    pin = new InputPin(_gpio.OpenPin(number));
                    break;
                case "IOutputPin":
                    pin = new OutputPin(_gpio.OpenPin(number));
                    break;
                default:
                    throw new ArgumentException($"Type {typeof(T)} not supported");
            }

            return (T)pin;
        }
        #endregion Methods

        #region Properties/Fields

        GpioController _gpio;

        #endregion

        #region ctor

        private PinController()
        {
            _gpio = GpioController.GetDefault();
        }

        #endregion ctor
    }
}