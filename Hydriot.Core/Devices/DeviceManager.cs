using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hydriot.Core.Devices
{
    public class DeviceManager : IDeviceManager
    {
        private DeviceManager()
        {
            _devices = new List<IDevice>();
        }

        #region Properties/Fields
        private List<IDevice> _devices;
        public IEnumerable<IDevice> Devices => _devices;
        #endregion


        #region Methods

        public Task InitializeAsync()
        {
            throw new System.NotImplementedException();
        }

        public void RegisterDevice(IDevice device)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        public static DeviceManager CreateManager()
        {
            return new DeviceManager();
        }
    }
}