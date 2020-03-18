using System;
using System.Collections.Generic;
using Liba.Logger.Implements;
using FiguresSorting.Business.Figures;
using FiguresSorting.Business.Models;
using FiguresSorting.Parser;

namespace FiguresSorting.Core
{
    public class AppEnvironment
    {
        #region Private Members

        private readonly TriangleParser triangleParser;
        private readonly AggregatedLogger logger;

        #endregion

        public AppEnvironment(
            string logPath = "application.log"
        )
        {
            logger = new AggregatedLogger(
                new FileLogger(logPath),
                new ConsoleLogger()
            );

            triangleParser = new TriangleParser();
        }

        public Figure Parse(string[] args)
        {
            if (!triangleParser.CanParse(args))
            {
                logger.LogInformation("Input data must be in format <Name> <sideA> <sideB> <sideC>");

                return null;
            }

            var triangle = triangleParser.Parse(args);

            return triangle;
        }

        public IEnumerable<Figure> RequestExtraFigures()
        {
            var figures = new List<Figure>();

            while (AddNewTriangleRequired())
            {
                var str = Console.ReadLine();

                var figure = GetTriangle(str);

                figures.Add(figure);
            }

            return figures.ToArray();
        }

        private Triangle GetTriangle(string str)
        {
            var digits = str.Split(' ');
            var triangle = triangleParser.Parse(digits);

            return triangle;
        }

        private bool AddNewTriangleRequired()
        {
            Console.WriteLine("Add a new triangle?");
            var response = Console.ReadLine();

            return string.Equals(response, "yes", StringComparison.InvariantCultureIgnoreCase)
                || string.Equals(response, "y", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}