namespace Hydriot.Core.Pins.Gpio
{
    public interface IGpioOutputPin : IGpioPin
    {
        /// <summary>
        /// Represents the value of the pin
        /// </summary>
        new PinValue PinValue { get; set; }

        /// <summary>
        /// Toggles the PinValue
        /// </summary>
        void Toggle();
    }
}