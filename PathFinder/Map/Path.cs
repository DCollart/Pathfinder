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

        public Path()
        {
            _steps = new HashSet<Coordinates>();
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

        public void AddStep(Coordinates coordinates)
        {
            if (!CanAddStep(coordinates))
            {
                throw new InvalidOperationException();
            }
            _steps.Add(coordinates);
        }

        public Coordinates Departure => _steps.First();
        public Coordinates Arrival => _steps.Last();

        public bool Contains(Coordinates coordinates)
        {
            return _steps.Contains(coordinates);
        }
        public static Path Create(IEnumerable<Coordinates> steps)
        {
            if (steps == null)
            {
                return null;
            }
            var path = new Path();
            foreach (var step in steps)
            {
                path.AddStep(step);
            }
            return path;
        }
    }
}
