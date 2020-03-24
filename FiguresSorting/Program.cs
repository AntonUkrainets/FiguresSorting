using System.Collections.Generic;
using System.Linq;
using FiguresSorting.Business.Models;
using FiguresSorting.ConsoleManagers;
using FiguresSorting.Core;

namespace FiguresSorting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConsoleManager consoleManager = new ConsoleManager();
            var environment = new AppEnvironment(consoleManager);

            var figures = new List<Figure>();

            var figure = environment.Parse(args);
            figures.Add(figure);

            var extraFigures = environment.RequestExtraFigures();
            figures.AddRange(extraFigures);

            var sortedAreas = figures
                .OrderByDescending(f => f.Area)
                .ToList();

            sortedAreas.ForEach(f => consoleManager.WriteLine($"[{f.Name}]: {f.Area} cm"));
        }
    }
}