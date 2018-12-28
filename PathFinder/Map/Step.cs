using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinder.Map
{
    public class Step
    {
        private const int DefaultWeight = 1;

        public Coordinates Coordinates { get; }
        public int Weight { get; }

        private Step(Coordinates coordinates, int weight = DefaultWeight)
        {
            Coordinates = coordinates;
            Weight = weight;
        }

        public static Step Create(Coordinates coordinates, int weight = DefaultWeight) => new Step(coordinates, weight);
    }
}
