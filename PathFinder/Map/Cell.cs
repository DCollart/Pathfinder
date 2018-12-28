using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinder.Map
{
    public class Cell
    {
        private const int DefaultWeight = 1;

        public CellType Type { get; }
        public Coordinates Coordinates { get; set; }
        public int Weight { get; set; }

        public Cell(CellType type, Coordinates coordinates, int weight = DefaultWeight)
        {
            Type = type;
            Coordinates = coordinates;
            Weight = weight;
        }
    }
}
