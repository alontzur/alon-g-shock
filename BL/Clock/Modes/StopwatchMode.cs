using ConsoleApp1.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace ConsoleApp1.BL.Clock.Modes
{
    internal class StopwatchMode : Mode
    {
        private Stopwatch _stopwatch;
        private Boolean _isRunning;
        private Timer _timer;
        public StopwatchMode(IOutput outputer) : base(outputer)
        {
            // Create a new stopwatch object
            _stopwatch = new Stopwatch();
            _isRunning = false;

            _timer = new Timer();
            _timer.Interval = 10;//to config
            _timer.Elapsed += _onTimerTick;
        }

        public override void OnStart() {
            _timer.Start();
        }

        public override void OnClose() {
            _timer.Close();
        }

        public override void ButtonA()
        {
            if (_isRunning) {
                _stopwatch.Stop();
            } else {
                _stopwatch.Start();
            }
            _isRunning = !_isRunning;
        }

        public override void ButtonB()
        {
            _stopwatch.Restart();
            _stopwatch.Stop();
            _isRunning = false;
        }


        private void _onTimerTick(object sender, EventArgs e)
        {
            // Get the elapsed time as a TimeSpan value
            TimeSpan ts = _stopwatch.Elapsed;

            // Format and display the elapsed time
            string elapsedTime = String.Format(ConfigurationSettings.AppSettings["timeSpanFormat"],
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            _outputer.Clear();
            _outputer.Print(elapsedTime);
        }
    }
}
