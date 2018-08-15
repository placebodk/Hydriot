using Windows.Devices.Gpio;

namespace Hydriot.Core.Pins
{
    public class PinValueChangedEventArgs
    {
        #region ctor

        public PinValueChangedEventArgs(GpioPinValueChangedEventArgs args)
        {
            Edge = (PinEdge)args.Edge;
        }

        #endregion ctor

        #region Properties/Fields

        public PinEdge Edge { get; }

        #endregion Properties/Fields
    }
}