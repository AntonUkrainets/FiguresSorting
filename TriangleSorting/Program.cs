using System;
using System.Linq;
using FiguresSorting.Core;

namespace FiguresSorting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environment = new AppEnvironment();

            var figures = environment.RequestExtraFigures().ToList();

            var figure = environment.Parse(args);
            if (figure == null)
                return;

            figures.Add(figure);

            var sortedAreas = figures
                .OrderByDescending(f => f.Area)
                .ToList();

            sortedAreas.ForEach(f => Console.WriteLine($"[{f.Name}]: {f.Area} cm"));
        }
    }
}