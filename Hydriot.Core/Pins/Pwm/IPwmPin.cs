using System;

namespace Hydriot.Core.Pins.Pwm
{
    /// <summary>
    /// Interface for a PulseWidthModulation pin
    /// </summary>
    public interface IPwmPin : IPin, IDisposable
    {
        /// <summary>
        /// Frequency
        /// </summary>
        double Frequency { get; }

        /// <summary>
        /// Min Pulse Width
        /// </summary>
        double MinPulseWidth { get; set; }

        /// <summary>
        /// Max Pulse Width
        /// </summary>
        double MaxPulseWidth { get; set; }

        /// <summary>
        /// Current Pulse Width
        /// </summary>
        double PulseWidth { get; set; }

        /// <summary>
        /// PulseWidthPrc
        /// </summary>
        double PulseWidthPrc { get; set; }
    }
}
