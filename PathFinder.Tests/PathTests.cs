using FluentAssertions;
using PathFinder.Map;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PathFinder.Tests
{
    public class PathTests
    {
        [Fact]
        public void CanAddStepToEmptyPath()
        {
            // Arrange 
            var path = new Path();

            // Act
            var canAdd = path.CanAddStep(new Coordinates(5, 5));

            // Assert
            canAdd.Should().BeTrue();
        }

        [Fact]
        public void CanAddStepIfInLastStepSurrounding()
        {
            // Arrange 
            var path = new Path();
            var firstStep = new Coordinates(5, 5);
            path.AddStep(firstStep);
            // Act
            var canAdd = path.CanAddStep(firstStep.Left);

            // Assert
            canAdd.Should().BeTrue();
        }

        [Fact]
        public void CannotAddStepIfNotInLastStepSurrounding()
        {
            // Arrange 
            var path = new Path();
            var firstStep = new Coordinates(5, 5);
            path = path.AddStep(firstStep);

            // Act
            var canAdd = path.CanAddStep(firstStep.Left.Left);

            // Assert
            canAdd.Should().BeFalse();
        }
    }
}
