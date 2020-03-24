using System;
using FiguresSorting.Business.Models;

namespace FiguresSorting.Business.Figures
{
    public sealed class Triangle : Figure
    {
        public override string Name { get; set; }

        public int SideA { get; private set; }

        public int SideB { get; private set; }

        public int SideC { get; private set; }

        private readonly Lazy<double> area;

        public override double Area => area.Value;

        public Triangle(string triangleName, int sideA, int sideB, int sideC)
        {
            Name = triangleName;

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            area = new Lazy<double>(() => GetArea());
        }

        public double GetArea()
        {
            var perimeter = GetPerimeter();

            var area = Math.Sqrt(perimeter * (perimeter - SideA) * (perimeter - SideB) * (perimeter - SideC));

            return RoundArea(area);
        }

        private double GetPerimeter()
        {
            var semiperimeter = 2d;
            double perimeter = (SideA + SideB + SideC) / semiperimeter;

            return perimeter;
        }

        private double RoundArea(double area)
        {
            return Math.Round(area, 2);
        }
    }
}