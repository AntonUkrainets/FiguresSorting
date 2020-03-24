using System;
using FiguresSorting.Business.Figures;
using FiguresSorting.Parser;
using FiguresSortingTests.Comparer;
using Xunit;

namespace FigureSortingTests.Parser
{
    public class TriangleParserTests
    {
        #region Private Members

        private readonly TriangleParser triangleParser;

        #endregion

        public TriangleParserTests()
        {
            triangleParser = new TriangleParser();
        }

        [Theory]
        [InlineData("0", "0", "0", "0")]
        [InlineData("-1", "-2", "-3", "-4")]
        [InlineData("1", "2", "3", "4")]
        public void CanParse_Positive(params string[] args)
        {
            // Act
            var actualValue = triangleParser.CanParse(args);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1")]
        [InlineData("1", "2", "3")]
        [InlineData("1", "2", "3", "4", "5")]
        public void CanParse_Negative(params string[] args)
        {
            // Act
            var actualValue = triangleParser.CanParse(args);

            // Assert
            Assert.False(actualValue);
        }

        [Theory]
        [InlineData("one", 10, 11, 12, "one", "10", "11", "12")]
        [InlineData("two", 3, 1, 2, "two", "3", "1", "2")]
        public void Parse(
            string name,
            int sideA,
            int sideB,
            int sideC,
            params string[] args
        )
        {
            // Arrange
            var expectedValue = new Triangle(name, sideA, sideB, sideC);

            // Act
            var actualValue = triangleParser.Parse(args);

            // Assert
            Assert.Equal(
                expectedValue,
                actualValue,
                new TriangleEqualityComparer()
            );
        }

        [Theory]
        [InlineData("a", "b", "c", "d")]
        public void Parse_TryConvertToInt(params string[] args)
        {
            // Assert
            Assert.Throws<FormatException>(() => triangleParser.Parse(args));
        }

        [Theory]
        [InlineData("-1", "-2", "-3", "-4")]
        public void Parse_CheckPositiveNumbers(params string[] args)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => triangleParser.Parse(args));
        }
    }
}