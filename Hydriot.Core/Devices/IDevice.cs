using Hydriot.Core.Pins;
using System;
using System.Collections.Generic;

namespace Hydriot.Core.Devices
{
    /// <summary>
    /// Models a device
    /// </summary>
    public interface IDevice : IDisposable
    {
        /// <summary>
        /// Pins registered to the device
        /// </summary>
        IEnumerable<IPin> Pins { get; }
    }
}