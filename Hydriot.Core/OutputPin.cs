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
            pin.SetDriveMode((Windows.Devices.Gpio.GpioPinDriveMode)mode);
        }

        #endregion ctor
    }
}