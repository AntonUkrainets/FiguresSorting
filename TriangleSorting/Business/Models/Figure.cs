namespace FiguresSorting.Business.Models
{
    public abstract class Figure
    {
        public abstract string Name { get; set; }

        public abstract double Area { get; }
    }
}