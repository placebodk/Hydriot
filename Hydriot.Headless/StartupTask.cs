using Hydriot.Core.Devices;
using Hydriot.Core.Pins;
using Hydriot.Core.Pins.Gpio;
using Hydriot.Core.Pins.Pwm;
using Microsoft.IoT.Lightning.Providers;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Devices;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace Hydriot.Headless
{
    public sealed class StartupTask : IBackgroundTask
    {
        private PinManager _manager;
        private IGpioOutputPin _ledPin1;
        private IGpioOutputPin _ledPin2;
        private IGpioOutputPin _ledPin3;
        IServo _servo;
        ISwitchButton _button;
        SingleDigitDisplayDevice _display;

        private int _counter;

        private bool _isActive;

        private double _servoCounter;

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            if (LightningProvider.IsLightningEnabled)
            {
                LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
            }

            var deferral = taskInstance.GetDeferral();

            await Initialize();

            try
            {
                await DoWork();
            }
            finally
            {
                deferral.Complete();
            }
        }

        private async Task Initialize()
        {
            _isActive = true;

            _manager = await PinManager.CreateAsync();
            _ledPin1 = _manager.CreatePin<IGpioOutputPin>(5);
            _ledPin2 = _manager.CreatePin<IGpioOutputPin>(25);
            _ledPin3 = _manager.CreatePin<IGpioOutputPin>(12);
            _button = new SwitchButton(_manager.CreatePin<IGpioInputPin>(26, DriveMode.InputPullUp));
            _button.ActiveAction = () => { _isActive = !_isActive; };

            _display = new SingleDigitDisplayDevice(_manager.CreatePin<IGpioOutputPin>(17), _manager.CreatePin<IGpioOutputPin>(18), _manager.CreatePin<IGpioOutputPin>(27));

            _servo = new Servo(_manager.CreatePin<IPwmPin>(13));
            
            _servo.DesiredAngle = 0;

            await _manager.InitializeAsync();
        }

        int _counter2;

        private async Task DoWork()
        {
            await Task.WhenAll(DoWork1(), DoWork2(), DoWork3());
        }

        private async Task DoWork1()
        {
            while (true)
            {
                if (_isActive)
                {
                    if (_counter2 >= 17)
                    {
                        _counter2 = 0;
                    }

                    _display.SetSegment(_counter2++);
                }

                await Task.Delay(200);
            }
        }

        private async Task DoWork2()
        {
            while (true)
            {
                if (_isActive)
                {
                    _ledPin1.Toggle();
                    if (_counter % 2 == 0) _ledPin2.Toggle();
                    if (_counter % 3 == 0) _ledPin3.Toggle();
                    _counter++;
                }

                await Task.Delay(100);
            }
        }

    private async Task DoWork3()
        {
#if false
            await Task.CompletedTask;
#else
            while (true)
            {
                if (_isActive)
                {
                    _servo.DesiredAngle = Math.Min(180.0, Math.Max(0.0, _servoCounter));

                    _servoCounter += 22.5;

                    if (_servoCounter > 180.0)
                    {
                        _servoCounter = 0;
                    }
                }

                await Task.Delay(1000);
            }
#endif
        }
    }
}