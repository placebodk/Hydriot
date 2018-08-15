using Hydriot.Core.Pins.Gpio;
using System;

namespace Hydriot.Core.Devices
{
    /// <summary>
    /// Models a button 
    /// </summary>
    public interface ISwitchButton : IDevice
    {
        /// <summary>
        /// Action triggered when activated
        /// </summary>
        Action ActiveAction { get; set; }

        /// <summary>
        /// Action triggered when deactivated
        /// </summary>
        Action DeactivateAction { get; set; }
    }
}