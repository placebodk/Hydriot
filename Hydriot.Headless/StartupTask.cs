using Hydriot.Core;
using System;
using Windows.ApplicationModel.Background;
using Windows.System.Threading;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace Hydriot.Headless
{
    public sealed class StartupTask : IBackgroundTask
    {
        private BackgroundTaskDeferral _deferral;
        private PinController _controller;
        private IOutputPin _ledPin1;
        private ThreadPoolTimer _timer;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();

            _controller = PinController.Create();
            _ledPin1 = _controller.CreatePin<IOutputPin>(5);

           _timer = ThreadPoolTimer.CreatePeriodicTimer(Timer_Tick,
           TimeSpan.FromMilliseconds(500));
        }

        private void Timer_Tick(ThreadPoolTimer timer)
        {
            if( _ledPin1.PinValue == PinValue.Low )
            {
                _ledPin1.PinValue = PinValue.High;
            }
            else
            {
                _ledPin1.PinValue = PinValue.Low;
            }
        }
    }
}