namespace Hydriot.Core
{
    /// <summary>
    /// Represents the controller on the Raspberry Pi
    /// </summary>
    public interface IPinController
    {
        /// <summary>
        /// Creates a pin representation on the raspberry pi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gpiopin"></param>
        /// <returns></returns>
        T CreatePin<T>(int gpiopin) where T:class;
    }
}