using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathFinder.Map
{
    public class Path
    {
        private HashSet<Step> _steps;

        public int Length => _steps.Count;

        private Path()
        {
            _steps = new HashSet<Step>();
        }

        private Path(Step step) : this()
        {
            _steps.Add(step);
        }

        private Path(Step[] steps) : this()
        {
            for (int i = 0; i < steps.Length; i++)
            {
                InternalAddStep(steps[i]);
            }
        }

        public Coordinates this[int index]
        {
            get
            {
                return _steps.ElementAt(index).Coordinates;
            }
        }

        public bool CanAddCoordinates(Coordinates step)
        {
            return !_steps.Any() || _steps.Last().Coordinates.Surrounding.Contains(step);
        }

        public Path AddStep(Step step)
        {
            if (!CanAddCoordinates(step.Coordinates))
            {
                throw new InvalidOperationException();
            }
            return Create(_steps.Concat(new[] { step }).ToArray());
        }

        private void InternalAddStep(Step step)
        {
            if (!CanAddCoordinates(step.Coordinates))
            {
                throw new InvalidOperationException();
            }
            _steps.Add(step);
        }

        public Coordinates Departure => _steps.First().Coordinates;

        public Coordinates Arrival => _steps.Last().Coordinates;

        public bool Contains(Coordinates coordinates)
        {
            return _steps.Select(s => s.Coordinates).Contains(coordinates);
        }

        public static Path Create(Step step)
        {
            if (step == null)
            {
                return null;
            }
            var path = new Path(step);
            return path;
        }

        public static Path Create(Step[] steps)
        {
            if (steps == null)
            {
                return null;
            }
            var path = new Path(steps);
            return path;
        }

        public static Path Empty => new Path();
    }
}
