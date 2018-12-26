using PathFinder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathFinder.Map
{
    public class Map
    {
        private Dictionary<Coordinates, Cell> _cells;

        public Map()
        {
            _cells = new Dictionary<Coordinates, Cell>();
        }

        public Cell GetCell(Coordinates coordinates)
        {
            return _cells[coordinates];
        }

        public void AddCell(Cell cell)
        {
            _cells[cell.Coordinates]= cell;
        }

        public Path FindPath(Coordinates departure, Coordinates arrival)
        {
            CheckCellIsOnMap(nameof(departure), departure);     
            CheckCellIsOnMap(nameof(arrival), arrival);
            CheckCellIsNotBlock(nameof(departure), departure);
            CheckCellIsNotBlock(nameof(arrival), arrival);

            var steps = FindPath(departure, new List<Coordinates>(), arrival, new List<Coordinates>());

            var path = Path.Create(steps);

            return path;
        }

        public Coordinates[] FindPath(Coordinates departure, List<Coordinates> steps, Coordinates arrival, List<Coordinates> alreadyVisited)
        {
            if (alreadyVisited.Contains(departure) || !_cells.ContainsKey(departure) || GetCell(departure).Type == CellType.Block)
            {
                return null;
            }
            var myPath = steps.Clone();
            myPath.Add(departure);
            alreadyVisited.Add(departure);

            if (myPath.Last() == arrival)
            {
                return myPath.ToArray();
            }

            var nextStep = departure.Surrounding.FirstOrDefault(s => s == arrival);
            if (nextStep != null)
            {
                myPath.Add(arrival);
                return myPath.ToArray();
            }

            foreach(var coord in departure.Surrounding)
            {
                var newPath = FindPath(coord, myPath, arrival, alreadyVisited);
                if (newPath != null)
                {
                    return newPath;
                }
            }

            return null;
        }

        private void CheckCellIsOnMap(string name, Coordinates coordinates)
        {
            if (!_cells.ContainsKey(coordinates))
            {
                throw new ArgumentException("Cell need to be on map", name);
            }
        }

        private void CheckCellIsNotBlock(string name, Coordinates coordinates)
        {
            if (_cells[coordinates].Type == CellType.Block)
            {
                throw new ArgumentException("Cell need not to be blocked", name);
            }
        }

        public Dictionary<Coordinates, Cell> GetAllCells()
        {
            return _cells.ToDictionary(e => e.Key, e => e.Value);
        }

    }
}
