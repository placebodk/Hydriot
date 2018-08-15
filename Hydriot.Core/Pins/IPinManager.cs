using System.Threading.Tasks;

namespace Hydriot.Core.Pins
{
    /// <summary>
    /// Represents the controller on the Raspberry Pi
    /// </summary>
    public interface IPinManager
    {
        /// <summary>
        /// Creates a pin representation on the raspberry pi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pinNumber"></param>
        /// <returns></returns>
        T CreatePin<T>(int pinNumber) where T:class;

        /// <summary>
        /// Creates a pin representation on the raspberry pi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pinNumber"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        T CreatePin<T>(int pinNumber, params object[] list) where T : class;

        /// <summary>
        /// Initilaizes the controller
        /// </summary>
        /// <returns></returns>
        Task InitializeAsync();
    }
}