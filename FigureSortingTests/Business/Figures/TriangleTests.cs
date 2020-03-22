using FiguresSorting.Business.Figures;
using Xunit;

namespace FiguresSortingTests.Business.Figures
{
    public class TriangleTests
    {
        [Theory]
        [InlineData("one", 1, 2, 3)]
        [InlineData("two", 4, 5, 6)]
        public void Ctor(
            string name,
            int sideA,
            int sideB,
            int sideC
        )
        {
            // Act
            var actualValue = new Triangle(name, sideA, sideB, sideC);

            // Assert
            Assert.Equal(name, actualValue.Name);
            Assert.Equal(sideA, actualValue.SideA);
            Assert.Equal(sideB, actualValue.SideB);
            Assert.Equal(sideC, actualValue.SideC);
        }

        [Theory]
        [InlineData("one", 10, 11, 12, 51.52)]
        [InlineData("two", 4, 5, 6, 9.92)]
        [InlineData("three", 20, 25, 30, 248.04)]
        public void GetArea(
            string name,
            int sideA,
            int sideB,
            int sideC,
            double expectedArea
        )
        {
            // Arrange
            var triangle = new Triangle(name, sideA, sideB, sideC);

            // Act
            var actualArea = triangle.GetArea();

            // Assert
            Assert.Equal(expectedArea, actualArea);
        }
    }
}