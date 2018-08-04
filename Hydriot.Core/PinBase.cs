using Windows.Devices.Gpio;

namespace Hydriot.Core
{
    internal abstract class PinBase : IPin
    {
        #region ctor

        internal PinBase(GpioPin pin)
        {
            _pin = pin;
        }

        #endregion ctor

        #region Properties/Fields

        public int PinNumber => _pin.PinNumber;

        public PinValue PinValue { get; }

        GpioPin _pin;

        #endregion Properties/Fields
    }
}