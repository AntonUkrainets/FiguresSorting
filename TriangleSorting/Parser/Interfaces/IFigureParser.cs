using FiguresSorting.Business.Figures;

namespace FiguresSorting.Parser.Interfaces
{
    public interface IFigureParser
    {
        bool CanParse(string[] args);
        Triangle Parse(string[] args);
    }
}