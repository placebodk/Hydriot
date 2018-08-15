using System;

namespace Hydriot.Core.Pins.Gpio
{
    /// <summary>
    /// Models an input pin
    /// </summary>
    public interface IGpioInputPin : IPin
    {
        /// <summary>
        /// Event triggered when the pin value is changed
        /// </summary>
        event EventHandler<PinValueChangedEventArgs> ValueChanged;

        /// <summary>
        /// Gets/Sets the interval of time after the ValueChanged event is triggered during which the changes in the pin will not trigger another ValueChanged event
        /// </summary>
        TimeSpan DebounceTimeout { get; set; }
    }
}
