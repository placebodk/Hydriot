using Windows.Devices.Gpio;

namespace Hydriot.Core.Pins.Gpio
{
    internal class GpioOutputPin : GpioPinBase, IGpioOutputPin
    {
        #region ctor

        internal GpioOutputPin(GpioPin pin) : this(pin, DriveMode.Output)
        {
        }

        internal GpioOutputPin(GpioPin pin, params object[] list) : base(pin)
        {
            pin.Write(Windows.Devices.Gpio.GpioPinValue.High);

            if (list != null)
            {
                if (list.Length > 0 && list[0] is DriveMode mode)
                {
                    pin.SetDriveMode((GpioPinDriveMode)mode);
                }
            }
        }
        

        #endregion ctor

        #region Properties/Fields

        public new PinValue PinValue
        {
            get { return base.PinValue; }
            set
            {
                _pin.Write((GpioPinValue)value);
            }
        }

        public void Toggle()
        {
            if (PinValue == PinValue.Low)
            {
                PinValue = PinValue.High;
            }
            else
            {
                PinValue = PinValue.Low;
            }
        }

        #endregion Properties/Fields
    }
}