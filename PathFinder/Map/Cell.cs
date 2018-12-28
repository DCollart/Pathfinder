using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinder.Map
{
    public class Cell
    {
        public CellType Type { get; }
        public Coordinates Coordinates { get; set; }
        public int Weight { get; set; }

        public Cell(CellType type, Coordinates coordinates)
        {
            Type = type;
            Coordinates = coordinates;
        }
    }
}
