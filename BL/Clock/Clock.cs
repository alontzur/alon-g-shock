using ConsoleApp1.BL.Clock.Modes;
using ConsoleApp1.UI;
using System.Security.Policy;

namespace ConsoleApp1.BL.Clock
{
    public class Clock
    {
        private Mode[] _modes;
        private int _currentModeIndex;
        private IOutput _outputer { get; set; }
        public Clock(Mode[] modes, IOutput outputer)
        {
            _modes = modes;
            _currentModeIndex = 0;
            _outputer = outputer;
        }

        public void start()
        {
            Console.WriteLine("press m to switch modes. " +
                "press a b c to activate mode buttons. press any key to start. press x to exit");
            string input = _outputer.Input();
            _modes[_currentModeIndex].OnStart();
            input = _outputer.Input();
            while (input != "x")
            {
                switch (input)
                {
                    case "a":
                        try { _modes[_currentModeIndex].ButtonA(); } catch { }
                        break;
                    case "b":
                        try { _modes[_currentModeIndex].ButtonB(); } catch { }
                        break;
                    case "c":
                        try { _modes[_currentModeIndex].ButtonC(); } catch { }
                        break;
                    case "m":
                        _modes[_currentModeIndex].OnClose();
                        _currentModeIndex = (_currentModeIndex + 1) % _modes.Length;
                        _modes[_currentModeIndex].OnStart();
                        break;
                }
                input = _outputer.Input();
            }

        }
    }
}
