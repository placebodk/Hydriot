namespace Hydriot.Core.Pins
{
    public enum DriveMode
    {
        //
        // Summary:
        //     Configures the GPIO pin in floating mode, with high impedance.
        Input = 0,

        //
        // Summary:
        //     Configures the GPIO pin in strong drive mode, with low impedance.
        Output = 1,

        //
        // Summary:
        //     Configures the GPIO pin as high impedance with a pull-up resistor to the voltage
        //     charge connection (VCC).
        InputPullUp = 2,
 
        //
        // Summary:
        //     Configures the GPIO pin as high impedance with a pull-down resistor to ground.
        InputPullDown = 3,

        //
        // Summary:
        //     Configures the GPIO in open drain mode.
        OutputOpenDrain = 4,

        //
        // Summary:
        //     Configures the GPIO pin in open drain mode with resistive pull-up mode.
        OutputOpenDrainPullUp = 5,

        //
        // Summary:
        //     Configures the GPIO pin in open collector mode.
        OutputOpenSource = 6,

        //
        // Summary:
        //     Configures the GPIO pin in open collector mode with resistive pull-down mode.
        OutputOpenSourcePullDown = 7
    }
}