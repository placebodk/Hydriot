using Hydriot.Core.Pins;
using Hydriot.Core.Pins.Gpio;
using System;

namespace Hydriot.Core.Devices
{
    public class SwitchButton : DeviceBase, ISwitchButton
    {
        #region ctor

        public SwitchButton(IGpioInputPin pin) : base(pin)
        {
            pin.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            pin.ValueChanged += ValueChanged;
        }

        #endregion ctor

        #region Properties/Fields

        public Action ActiveAction { get; set; }
        public Action DeactivateAction { get; set; }

        #endregion Properties/Fields

        #region Methods

        private void ValueChanged(object sender, PinValueChangedEventArgs args)
        {
            if (args.Edge == PinEdge.RisingEdge)
            {
                ActiveAction?.Invoke();
            }
            else if (args.Edge == PinEdge.FallingEdge)
            {
                DeactivateAction?.Invoke();
            }
        }

        #endregion Methods
    }
}