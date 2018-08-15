namespace Hydriot.Core.Pins.Gpio
{
    public interface IGpioPin : IPin
    {
        /// <summary>
        /// Represents the value of the pin
        /// </summary>
        PinValue PinValue { get; }
    }
}