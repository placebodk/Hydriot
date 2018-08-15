using System.Threading.Tasks;

namespace Hydriot.Core.Pins
{
    /// <summary>
    /// Represents a GPIO pin on the Raspberry Pi
    /// </summary>
    public interface IPin
    {
        /// <summary>
        /// Pin number
        /// </summary>
        int PinNumber { get; }

        /// <summary>
        /// Initializes the pin
        /// </summary>
        /// <returns></returns>
        Task InitializeAsync();
    }
}