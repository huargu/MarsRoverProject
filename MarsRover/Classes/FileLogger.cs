using System;
using System.IO;
using MarsRover.Interfaces;

namespace MarsRover.Classes
{
    public class FileLogger : ILogger
    {
        private string filePath = string.Empty;

        public FileLogger(string path)
        {
            this.filePath = path;
        }
        public void AddLog(string logMessage)
        {
            File.AppendAllText(filePath, logMessage + Environment.NewLine);
        }
    }
}