using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FiguresSorting.Business.Figures;

namespace FiguresSortingTests.Comparer
{
    public class TriangleEqualityComparer : EqualityComparer<Triangle>
    {
        public override bool Equals(
            [AllowNull] Triangle a,
            [AllowNull] Triangle b
        )
        {
            return a.SideA == b.SideA
                && a.SideB == b.SideB
                && a.SideC == b.SideC;
        }

        public override int GetHashCode([DisallowNull] Triangle obj)
        {
            return obj.GetHashCode();
        }
    }
}