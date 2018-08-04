using Windows.Devices.Gpio;

namespace Hydriot.Core
{
    internal class InputPin : PinBase, IInputPin
    {
        #region ctor
        public InputPin(GpioPin pin) : this(pin, DriveMode.Input)
        {
            pin.SetDriveMode(GpioPinDriveMode.Input);
        }

        public InputPin(GpioPin pin, DriveMode mode) : base(pin)
        {
            pin.SetDriveMode((Windows.Devices.Gpio.GpioPinDriveMode)mode);
        }
        #endregion
    }
}