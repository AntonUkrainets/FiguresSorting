using System;
using System.Collections.Generic;
using System.Linq;
using FiguresSorting.Business.Figures;
using FiguresSorting.ConsoleManagers;
using FiguresSorting.Core;
using FiguresSortingTests.Comparer;
using Moq;
using Xunit;

namespace FiguresSortingTests.Core
{
    public class AppEnvironmentTests
    {
        #region Private Members

        private readonly Mock<IConsoleManager> mockConsoleManager;
        private readonly AppEnvironment environment;

        #endregion

        public AppEnvironmentTests()
        {
            mockConsoleManager = new Mock<IConsoleManager>();
            environment = new AppEnvironment(mockConsoleManager.Object);
        }

        [Theory]
        [InlineData("one", 4, 5, 6, "one", "4", "5", "6")]
        [InlineData("two", 1, 2, 3, "two", "1", "2", "3")]
        [InlineData("three", 10, 11, 12, "three", "10", "11", "12")]
        public void Parse(
            string name,
            int sideA,
            int sideB,
            int sideC,
            params string[] args)
        {
            var expectedTriangle = new Triangle(name, sideA, sideB, sideC);

            // Act
            var actualTriangle = (Triangle)environment.Parse(args);

            // Assert
            Assert.Equal(expectedTriangle.Name, actualTriangle.Name);
            Assert.Equal(expectedTriangle.SideA, actualTriangle.SideA);
            Assert.Equal(expectedTriangle.SideB, actualTriangle.SideB);
            Assert.Equal(expectedTriangle.SideC, actualTriangle.SideC);
        }

        [Theory]
        [InlineData("one 3 4 5", "two 4 5 6")]
        public void RequestExtraFigures(params string[] inputString)
        {
            // Arrange
            var expectedTriangles = new Triangle[]
            {
                new Triangle("one", 3, 4, 5),
                new Triangle("two", 4, 5, 6)
            };

            var consoleUserResponses = new Queue<string>(
                new[]
                {
                    "yEs",
                    inputString[0],
                    "yes",
                    inputString[1],
                    "no"
                }
            );

            var mockConsoleManager = new Mock<IConsoleManager>();
            mockConsoleManager
                .Setup(c => c.ReadLine())
                .Returns(() => consoleUserResponses.Dequeue());

            var environment = new AppEnvironment(mockConsoleManager.Object);

            // Act
            var actualTriangles = environment
                .RequestExtraFigures()
                .Cast<Triangle>();

            // Assert
            var equalityComparer = new TriangleEqualityComparer();

            Assert.Equal(
                expectedTriangles,
                actualTriangles,
                equalityComparer);
        }

        [Theory]
        [InlineData("a", "0", "0", "0")]
        [InlineData("b", "-1", "-2", "-3")]
        public void Parse_CheckPositiveNumbers(params string[] args)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => environment.Parse(args));
        }

        [Theory]
        [InlineData("a", "b", "c", "d")]
        public void Parse_TryConvertToInt(params string[] args)
        {
            // Assert
            Assert.Throws<FormatException>(() => environment.Parse(args));
        }
    }
}