namespace Hydriot.Core
{
    public interface IOutputPin : IPin
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