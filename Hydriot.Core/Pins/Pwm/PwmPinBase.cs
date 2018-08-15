using Microsoft.IoT.Lightning.Providers;
using System;
using System.Threading.Tasks;
using Windows.Devices.Pwm;

namespace Hydriot.Core.Pins.Pwm
{
    internal class PwmPinBase : IPwmPin
    {
        #region ctor

        public PwmPinBase(PwmPin pin, int pinNumber, double frequency)
        {
            PinNumber = pinNumber;
            _pin = pin;
            Frequency = frequency;
            MinPulseWidth = 0.0008;
            MaxPulseWidth = 0.0026;
        }

        #endregion ctor

        #region Properties/Fields

        public int PinNumber { get; }
        public double MinPulseWidth { get; set; }
        public double MaxPulseWidth { get; set; }

        public double PulseWidth
        {
            get
            {
                return _pulseWidth;
            }
            set
            {
                if (value < MinPulseWidth)
                {
                    _pulseWidth = MinPulseWidth;
                }
                else if (value > MaxPulseWidth)
                {
                    _pulseWidth = MaxPulseWidth;
                }
                else
                {
                    _pulseWidth = value;
                }
                UpdatePwm(_pulseWidth);
            }
        }

        private double _pulseWidth;

        public double Frequency { get; }

        public double PulseWidthPrc
        {
            get
            {
                return (MaxPulseWidth - _pulseWidth) / (MaxPulseWidth - MinPulseWidth);
            }
            set
            {
                if (value < 0.0 || value > 1.0)
                {
                    throw new ArgumentException("Unable to handle prc<0.0 && prc > 1.0");
                }

                PulseWidth = MinPulseWidth + (MaxPulseWidth - MinPulseWidth) * value;
            }
        }

        protected PwmPin _pin;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Properties/Fields

        #region Methods

        virtual protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pin.Stop();
                _pin.Dispose();
                _pin = null;
            }
        }

        public virtual Task InitializeAsync()
        {
            if (!LightningProvider.IsLightningEnabled)
            {
                throw new NotSupportedException("PwmPinBase is not supported outside Lightning Provider");
            }

            _pin.Start();
            return Task.CompletedTask;
        }

        private void UpdatePwm(double pulseWidth)
        {
            var prc = pulseWidth * Frequency;
            try
            {
                _pin.SetActiveDutyCyclePercentage(prc);
            }
            catch( Exception e )
            {
                //
                int fisk = 0; 
            }
        }

        #endregion Methods
    }
}