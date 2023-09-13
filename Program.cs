using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;
using ConsoleApp1.UI;
using ConsoleApp1.BL.Clock;
using ConsoleApp1.BL.Clock.Modes;
using System.Collections;
using System.Diagnostics;

namespace ConsoleApp1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleOutput output = new ConsoleOutput();
            Mode[] modes = { new CurrentTimeMode(output), new StopwatchMode(output) };
            Clock clock = new Clock(modes, output);
            clock.start();

            // Wait for user input to exit
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
