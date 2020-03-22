using System;
using Liba.Logger.Interfaces;

namespace Liba.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow:yyyy.MM.dd HH:mm:ss} {message}");
        }
    }
}