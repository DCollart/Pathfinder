using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathFinder.Map
{
    public class Path
    {
        private HashSet<Coordinates> _steps;

        public int Length => _steps.Count;

        private Path()
        {
            _steps = new HashSet<Coordinates>();
        }

        private Path(Coordinates step) : this()
        {
            _steps.Add(step);
        }

        private Path(Coordinates[] steps) : this()
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
                return _steps.ElementAt(index);
            }
        }

        public bool CanAddStep(Coordinates step)
        {
            return !_steps.Any() || _steps.Last().Surrounding.Contains(step);
        }

        public Path AddStep(Coordinates step)
        {
            if (!CanAddStep(step))
            {
                throw new InvalidOperationException();
            }
            return Create(_steps.Concat(new[] { step }).ToArray());
        }

        private void InternalAddStep(Coordinates step)
        {
            if (!CanAddStep(step))
            {
                throw new InvalidOperationException();
            }
            _steps.Add(step);
        }

        public Coordinates Departure => _steps.First();

        public Coordinates Arrival => _steps.Last();

        public bool Contains(Coordinates coordinates)
        {
            return _steps.Contains(coordinates);
        }

        public static Path Create(Coordinates step)
        {
            if (step == null)
            {
                return null;
            }
            var path = new Path(step);
            return path;
        }

        public static Path Create(Coordinates[] steps)
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
