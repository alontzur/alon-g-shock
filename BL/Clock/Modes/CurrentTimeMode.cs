using ConsoleApp1.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ConsoleApp1.BL.Clock.Modes
{
    public class CurrentTimeMode : Mode
    {
        private Timer _timer;
        public CurrentTimeMode(IOutput outputer) : base(outputer) {
            _timer = new Timer();
            _timer.Interval = Int16.Parse(ConfigurationSettings.AppSettings["defaultMsInterval"]);
            _timer.Elapsed += _onTimerTick;
        }

        public override void OnStart()
        {
            _timer.Start();
        }

        public override void OnClose()
        {
            _timer.Stop();
        }

        public override void ButtonA()
        {
            throw new NotImplementedException();
        }

        public override void ButtonB()
        {
            throw new NotImplementedException();
        }


        private void _onTimerTick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string format = ConfigurationSettings.AppSettings["currentTimeModeFormat"];

            _outputer.Clear();
            _outputer.Print(now.ToString(format));
        }
    }
}
