using Hydriot.Core.Pins.Pwm;
using System;

namespace Hydriot.Core.Devices
{
    public class Servo : DeviceBase, IServo
    {
        #region ctor

        public Servo(IPwmPin pin)
        {
            _pin = pin;
            RegisterPin(pin);
            _maxAngle = 180;
        }

        #endregion ctor

        #region Properties/Fields

        IPwmPin _pin;

        public double DesiredAngle
        {
            get
            {
                return _pin.PulseWidthPrc * _maxAngle;
            }
            set
            {
                if (value < 0 || value > _maxAngle)
                {
                    throw new ArgumentException($"The angle of the servo must be with 0 and {_maxAngle}");
                }

                _pin.PulseWidthPrc = value / _maxAngle;
            }
        }

        private int _maxAngle;

        #endregion Properties/Fields

        #region Methods


        #endregion Methods
    }
}