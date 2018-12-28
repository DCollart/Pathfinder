using FluentAssertions;
using PathFinder.Map;
using System;
using Xunit;

namespace PathFinder.Tests
{
    public class MapLoaderTests
    {
        [Fact]
        public void LoadMapAShouldBeSuccessfull()
        {
            // Act
            var map = MapLoader.MapLoader.LoadFromFile("MapA.txt");

            // Assert
            map.Should().NotBeNull();

            // First line
            map.GetCell(new Coordinates(0, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(2, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(3, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(4, 0)).Type.Should().Be(CellType.Block);


            // Second line
            map.GetCell(new Coordinates(0, 1)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 1)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(2, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(3, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(4, 1)).Type.Should().Be(CellType.Block);


            // Third line
            map.GetCell(new Coordinates(0, 2)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 2)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(2, 2)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(3, 2)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(4, 2)).Type.Should().Be(CellType.Block);

            // Fourth line
            map.GetCell(new Coordinates(0, 3)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 3)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(2, 3)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(3, 3)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(4, 3)).Type.Should().Be(CellType.Block);

            // Fifth line
            map.GetCell(new Coordinates(0, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(2, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(3, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(4, 4)).Type.Should().Be(CellType.Block);
        }

        [Fact]
        public void LoadMapBShouldBeSuccessfull()
        {
            // Act
            var map = MapLoader.MapLoader.LoadFromFile("MapB.txt");

            // Assert
            map.Should().NotBeNull();

            // First line
            map.GetCell(new Coordinates(0, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(2, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(3, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(4, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(5, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(6, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(7, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(8, 0)).Type.Should().Be(CellType.Block);

            // Second line
            map.GetCell(new Coordinates(0, 1)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(2, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(3, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(4, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(5, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(6, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(7, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(8, 1)).Type.Should().Be(CellType.Block);

            // Third line
            map.GetCell(new Coordinates(0, 2)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 2)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(2, 2)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(3, 2)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(4, 2)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(5, 2)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(6, 2)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(7, 2)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(8, 2)).Type.Should().Be(CellType.Block);

            // Fourth line
            map.GetCell(new Coordinates(0, 3)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 3)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(2, 3)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(3, 3)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(4, 3)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(5, 3)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(6, 3)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(7, 3)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(8, 3)).Type.Should().Be(CellType.Block);

            // Fifth line
            map.GetCell(new Coordinates(0, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 4)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(2, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(3, 4)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(4, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(5, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(6, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(7, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(8, 4)).Type.Should().Be(CellType.Block);

            // Sixth line
            map.GetCell(new Coordinates(0, 5)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 5)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(2, 5)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(3, 5)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(4, 5)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(5, 5)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(6, 5)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(7, 5)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(8, 5)).Type.Should().Be(CellType.Block);

            // Seventh line
            map.GetCell(new Coordinates(0, 6)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 6)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(2, 6)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(3, 6)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(4, 6)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(5, 6)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(6, 6)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(7, 6)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(8, 6)).Type.Should().Be(CellType.Block);
        }

        [Fact]
        public void LoadMapEWithWeightingShouldBeSuccessfull()
        {
            // Act
            var map = MapLoader.MapLoader.LoadFromFile("MapE.txt");

            // Assert
            map.Should().NotBeNull();

            // First line
            map.GetCell(new Coordinates(0, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(2, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(3, 0)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(4, 0)).Type.Should().Be(CellType.Block);


            // Second line
            map.GetCell(new Coordinates(0, 1)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(2, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(2, 1)).Weight.Should().Be(9);
            map.GetCell(new Coordinates(3, 1)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(4, 1)).Type.Should().Be(CellType.Block);


            // Third line
            map.GetCell(new Coordinates(0, 2)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 2)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(1, 2)).Weight.Should().Be(1);
            map.GetCell(new Coordinates(2, 2)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(3, 2)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(3, 2)).Weight.Should().Be(2);
            map.GetCell(new Coordinates(4, 2)).Type.Should().Be(CellType.Block);

            // Fourth line
            map.GetCell(new Coordinates(0, 3)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 3)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(2, 3)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(2, 3)).Weight.Should().Be(5);
            map.GetCell(new Coordinates(3, 3)).Type.Should().Be(CellType.Classic);
            map.GetCell(new Coordinates(4, 3)).Type.Should().Be(CellType.Block);

            // Fifth line
            map.GetCell(new Coordinates(0, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(1, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(2, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(3, 4)).Type.Should().Be(CellType.Block);
            map.GetCell(new Coordinates(4, 4)).Type.Should().Be(CellType.Block);
        }

    }
}
