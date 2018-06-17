using System;
using MarsRover.Interfaces;

namespace MarsRover.Classes
{
    public class ConsoleLogger : ILogger
    {
        public void AddLog(string logMessage)
        {
            Console.WriteLine(logMessage);
        }
    }
}