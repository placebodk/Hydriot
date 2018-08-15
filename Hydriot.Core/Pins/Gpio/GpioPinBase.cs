using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Hydriot.Core.Pins.Gpio
{
    internal abstract class GpioPinBase : IPin
    {
        #region ctor

        internal GpioPinBase(GpioPin pin)
        {
            _pin = pin;
        }

        #endregion ctor

        #region Methods

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        #endregion Methods

        #region Properties/Fields

        public int PinNumber => _pin.PinNumber;

        public PinValue PinValue
        {
            get
            {
                return (PinValue)_pin.Read();
            }
        }

        protected GpioPin _pin;

        #endregion Properties/Fields
    }
}