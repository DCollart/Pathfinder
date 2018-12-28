﻿using FluentAssertions;
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
            var path = Path.Empty;

            // Act
            var canAdd = path.CanAddCoordinates(new Coordinates(5, 5));

            // Assert
            canAdd.Should().BeTrue();
        }

        [Fact]
        public void CanAddStepIfInLastStepSurrounding()
        {
            // Arrange 
            var path = Path.Empty;
            var firstStep = Step.Create(new Coordinates(5, 5), 1);
            path.AddStep(firstStep);
            // Act
            var canAdd = path.CanAddCoordinates(firstStep.Coordinates.Left);

            // Assert
            canAdd.Should().BeTrue();
        }

        [Fact]
        public void CannotAddStepIfNotInLastStepSurrounding()
        {
            // Arrange 
            var path = Path.Empty;
            var firstStep = Step.Create(new Coordinates(5, 5), 1);
            path = path.AddStep(firstStep);

            // Act
            var canAdd = path.CanAddCoordinates(firstStep.Coordinates.Left.Left);

            // Assert
            canAdd.Should().BeFalse();
        }
    }
}
