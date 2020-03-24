using System;

namespace FiguresSorting.ConsoleManagers
{
    public class ConsoleManager : IConsoleManager
    {
        public string ReadLine()
        {
            var inputString = Console.ReadLine();

            return inputString;
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}