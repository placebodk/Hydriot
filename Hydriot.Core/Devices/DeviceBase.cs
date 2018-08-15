using Hydriot.Core.Pins;
using System;
using System.Collections.Generic;

namespace Hydriot.Core.Devices
{
    public class DeviceBase : IDevice
    {
        #region ctor

        public DeviceBase( params IPin[] pins )
        {
            Pins = new List<IPin>( pins );
        }

        #endregion ctor

        #region Methods

        protected void RegisterPin(IPin pin)
        {
            Pins.Add(pin);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose( bool disposing )
        {
        }

        #endregion Methods

        #region Properties/Fields

        public List<IPin> Pins { get; private set; }

        IEnumerable<IPin> IDevice.Pins => Pins;

        #endregion Properties/Fields
    }
}