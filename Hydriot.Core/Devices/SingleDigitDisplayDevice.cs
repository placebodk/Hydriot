using Hydriot.Core.Pins.Gpio;

namespace Hydriot.Core.Devices
{
    public class SingleDigitDisplayDevice : _74HC595Device
    {
        #region ctor

        public SingleDigitDisplayDevice(IGpioOutputPin pinSdi, IGpioOutputPin pinRClk, IGpioOutputPin pinSrclk) : base(pinSdi, pinRClk, pinSrclk)
        {
        }

        #endregion ctor

        #region Properties/Fields

        private byte[] _segments = new byte[] { 0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7d, 0x07, 0x7f, 0x6f, 0x77, 0x7c, 0x39, 0x5e, 0x79, 0x71, 0x80 };

        #endregion Properties/Fields

        #region Methods

        public void SetSegment(int index)
        {
            SIPO(_segments[index]);
            PulseRCLK();
        }

        #endregion Methods
    }
}