using FluentAssertions;
using PathFinder.Map;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PathFinder.Tests
{
    public class CoordinatesTests
    {
        [Fact]
        public void CanGetSurroundingCoordinates()
        {
            // Arrange
            Coordinates coord = new Coordinates(3, 3);

            // Act 
            var left = coord.Left;
            var right = coord.Right;
            var up = coord.Up;
            var down = coord.Down;
            var surrounding = coord.Surrounding;

            // Assert
            left.Should().Be(new Coordinates(2, 3));
            right.Should().Be(new Coordinates(4, 3));
            up.Should().Be(new Coordinates(3, 2));
            down.Should().Be(new Coordinates(3, 4));
            surrounding.Should().HaveCount(4);
            surrounding.Should().Contain(new[] { left, right, up, down });
        }
    }
}
