using System;
using FiguresSorting.Business.Figures;
using FiguresSorting.Parser.Interfaces;

namespace FiguresSorting.Parser
{
    public class TriangleParser : IFigureParser
    {
        public bool CanParse(string[] args)
        {
            return args.Length == 4;
        }

        public Triangle Parse(string[] args)
        {
            TryConvertToInt(args[1], out int sideA);
            CheckPositiveNumbers(sideA);

            TryConvertToInt(args[2], out int sideB);
            CheckPositiveNumbers(sideB);

            TryConvertToInt(args[3], out int sideC);
            CheckPositiveNumbers(sideC);

            return new Triangle
                (
                    triangleName: args[0],
                    sideA,
                    sideB,
                    sideC
                );
        }

        private void TryConvertToInt(string inputString, out int side)
        {
            if (!int.TryParse(inputString, out side))
                throw new FormatException($"Can't convert '{side}' to int.");
        }

        private void CheckPositiveNumbers(double value)
        {
            if (value <= 0)
                throw new ArgumentException($"Number '{value}' must be greather than '0'");
        }
    }
}