using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PathFinder.Tests
{
    public class MapTests
    {
        [Fact]
        public void ImpossiblePathFinderShouldBeNull()
        {
            // Arrange 
            var map = MapLoader.MapLoader.LoadFromFile("MapC.txt");

            // Act
            var path = map.FindPath(new Map.Coordinates(1, 1), new Map.Coordinates(3, 3));

            // Assert
            path.Should().BeNull();
        }

        [Fact]
        public void DepartureOrArrivalOutOfTheMapShouldThrowAnException()
        {
            // Arrange 
            var map = MapLoader.MapLoader.LoadFromFile("MapC.txt");

            // Act & Assert
            Assert.Throws<ArgumentException>("departure", () => map.FindPath(new Map.Coordinates(10, 1), new Map.Coordinates(3, 3)));    
            Assert.Throws<ArgumentException>("arrival", () => map.FindPath(new Map.Coordinates(1, 1), new Map.Coordinates(10, 3)));
        }

        [Fact]
        public void DepartureOrArrivalOnBlockCellShouldThrowAnException()
        {
            // Arrange 
            var map = MapLoader.MapLoader.LoadFromFile("MapC.txt");

            // Act & Assert
            Assert.Throws<ArgumentException>("departure", () => map.FindPath(new Map.Coordinates(0, 0), new Map.Coordinates(3, 3)));
            Assert.Throws<ArgumentException>("arrival", () => map.FindPath(new Map.Coordinates(1, 1), new Map.Coordinates(0, 0)));
        }

        [Fact]
        public void SameCoordinatesForDepartureAndArrivalShouldBeSuccessfull()
        {
            // Arrange 
            var map = MapLoader.MapLoader.LoadFromFile("MapC.txt");

            // Act
            var path = map.FindPath(new Map.Coordinates(1, 1), new Map.Coordinates(1, 1));

            // Assert
            path.Should().NotBeNull();
            path.Length.Should().Be(1);
            path[0].Should().Be(new Map.Coordinates(1, 1));
        }


        [Fact]
        public void AccessibleCellWithMapCShouldBeSuccessfull()
        {
            // Arrange 
            var map = MapLoader.MapLoader.LoadFromFile("MapC.txt");

            // Act
            var path = map.FindPath(new Map.Coordinates(1, 1), new Map.Coordinates(3, 1));

            // Assert
            path.Should().NotBeNull();
            path.Length.Should().Be(3);
            path[0].Should().Be(new Map.Coordinates(1, 1));
            path[1].Should().Be(new Map.Coordinates(2, 1));
            path[2].Should().Be(new Map.Coordinates(3, 1));
        }

        [Fact]
        public void AccessibleCellWithMapAShouldBeSuccessfull()
        {
            // Arrange 
            var map = MapLoader.MapLoader.LoadFromFile("MapA.txt");

            // Act
            var path = map.FindPath(new Map.Coordinates(3, 1), new Map.Coordinates(1, 3));

            // Assert
            path.Should().NotBeNull();
            path.Length.Should().Be(5);
        }

        [Fact]
        public void AccessibleCellWithMapBShouldBeSuccessfull()
        {
            // Arrange 
            var map = MapLoader.MapLoader.LoadFromFile("MapB.txt");

            // Act
            var path = map.FindPath(new Map.Coordinates(1, 5), new Map.Coordinates(7, 5));

            // Assert
            path.Should().NotBeNull();
            path.Length.Should().Be(23);
        }

        [Fact]
        public void AccessibleCellWithMapEAndWeightingShouldBeSuccessfull()
        {
            // Arrange 
            var map = MapLoader.MapLoader.LoadFromFile("MapB.txt");

            // Act
            var path = map.FindPath(new Map.Coordinates(1, 1), new Map.Coordinates(3, 1));

            // Assert
            path.Should().NotBeNull();
            path.Length.Should().Be(5);
        }

    }
}
