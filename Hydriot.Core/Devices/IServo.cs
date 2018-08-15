namespace Hydriot.Core.Devices
{
    /// <summary>
    /// Models a servo
    /// </summary>
    public interface IServo : IDevice
    {
        /// <summary>
        /// Desired angle
        /// </summary>
        double DesiredAngle { get; set; }
    }
}