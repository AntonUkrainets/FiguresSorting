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
            TryConvertToInt(args[2], out int sideB);
            TryConvertToInt(args[3], out int sideC);

            return new Triangle
                (
                    triangleName: args[0],
                    sideA,
                    sideB,
                    sideC
                );
        }

        private void TryConvertToInt(string str, out int value)
        {
            if (!int.TryParse(str, out value))
                throw new ArgumentException($"Can't convert '{value}' to int.");
        }
    }
}