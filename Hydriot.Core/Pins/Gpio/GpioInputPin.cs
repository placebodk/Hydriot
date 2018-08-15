using Hydriot.Core.Extensions;
using System;
using Windows.Devices.Gpio;

namespace Hydriot.Core.Pins.Gpio
{
    internal class GpioInputPin : GpioPinBase, IGpioInputPin
    {
        #region ctor

        public GpioInputPin(GpioPin pin) : this(pin, DriveMode.Input)
        {
        }

        public GpioInputPin(GpioPin pin, params object[] list) : base(pin)
        {
            var driveMode = list.FirstOfType<DriveMode>();
            if (driveMode != null)
            {
                if (pin.IsDriveModeSupported((GpioPinDriveMode)driveMode))
                {
                    pin.SetDriveMode((GpioPinDriveMode)driveMode);
                }
                else
                {
                    pin.SetDriveMode(GpioPinDriveMode.Input);
                }
            }
            else
            {
                pin.SetDriveMode(GpioPinDriveMode.Input);
            }

            pin.ValueChanged += ButtonValueChanged;
        }

        protected virtual void ButtonValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            ValueChanged?.Invoke(this, new PinValueChangedEventArgs(args));
        }

        #endregion ctor

        #region Properties/Fields

        public event EventHandler<PinValueChangedEventArgs> ValueChanged;

        public TimeSpan DebounceTimeout
        {
            get
            {
                return _pin.DebounceTimeout;
            }
            set
            {
                _pin.DebounceTimeout = value;
            }
        }

        #endregion Properties/Fields
    }
}