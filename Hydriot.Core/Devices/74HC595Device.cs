using Hydriot.Core.Pins;
using Hydriot.Core.Pins.Gpio;

namespace Hydriot.Core.Devices
{
    public class _74HC595Device : DeviceBase, IDevice
    {
        #region ctor

        public _74HC595Device(IGpioOutputPin pinSdi, IGpioOutputPin pinRClk, IGpioOutputPin pinSrclk)
        {
            PinSDI = pinSdi;
            PinRCLK = pinRClk;
            PinSRCLK = pinSrclk;

            PinSDI.PinValue = PinValue.Low;
            PinRCLK.PinValue = PinValue.Low;
            PinSRCLK.PinValue = PinValue.Low;
        }

        #endregion ctor

        #region Properties/Fields

        // Serial Digital Input
        public IGpioOutputPin PinSDI { get; }
        
        // Register Clock
        public IGpioOutputPin PinRCLK { get; }

        // Serial Clock
        public IGpioOutputPin PinSRCLK { get; }

        #endregion Properties/Fields

        #region Methods
        // Serial-In-Parallel-Out
        protected void SIPO(byte b)
        {
            for (var i = 0; i < 8; i++)
            {
                PinSDI.PinValue = ((b & (0x80 >> i)) > 0 ? PinValue.High : PinValue.Low );
                PulseSRCLK();
            }
        }

        // Pulse Register Clock
        protected void PulseRCLK()
        {
            PinRCLK.PinValue = PinValue.Low;
            PinRCLK.PinValue = PinValue.High;
        }

        // Pulse Serial Clock
        protected void PulseSRCLK()
        {
            PinSRCLK.PinValue = PinValue.Low;
            PinSRCLK.PinValue = PinValue.High;
        }
        #endregion
    }
}