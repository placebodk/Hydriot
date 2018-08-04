namespace Hydriot.Core
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
    }
}