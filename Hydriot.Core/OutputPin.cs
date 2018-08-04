using Windows.Devices.Gpio;

namespace Hydriot.Core
{
    internal class OutputPin : PinBase, IOutputPin
    {
        #region ctor

        internal OutputPin(GpioPin pin) : this(pin, DriveMode.Output)
        {
        }

        internal OutputPin(GpioPin pin, DriveMode mode) : base(pin)
        {
            pin.Write(GpioPinValue.High);
            pin.SetDriveMode((GpioPinDriveMode)mode);
        }

        #endregion ctor

        #region Properties/Fields

        public new PinValue PinValue { get; set; }

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