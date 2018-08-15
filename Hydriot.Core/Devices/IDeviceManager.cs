using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hydriot.Core.Devices
{
    /// <summary>
    /// A manager for devices
    /// </summary>
    public interface IDeviceManager
    {
        /// <summary>
        /// Regiseters a device in the device manager
        /// </summary>
        /// <param name="device"></param>
        void RegisterDevice(IDevice device);

        /// <summary>
        /// The registered devices
        /// </summary>
        IEnumerable<IDevice> Devices { get; }

        /// <summary>
        /// Initializes the device manger
        /// </summary>
        /// <returns></returns>
        Task InitializeAsync();
    }
}