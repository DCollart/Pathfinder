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

            Dictionary<Coordinates, Path> potentialPaths = new Dictionary<Coordinates, Path>();

            foreach(var keyValue in _cells.Where(kv => kv.Value.Type != CellType.Block))
            {
                potentialPaths[keyValue.Key] = keyValue.Key == departure ? Path.Create(new[] { departure }) : null;
            }

            while (potentialPaths[arrival] == null)
            {
                bool newCellDiscovered = false;
                var knownCells = potentialPaths.Where(p => p.Value != null).Select(p => p.Key).ToList();
                foreach (var coordinates in knownCells)
                {
                    foreach(Coordinates neighbor in coordinates.Surrounding)
                    {
                        if (potentialPaths.ContainsKey(neighbor) && potentialPaths[neighbor] == null)
                        {
                            newCellDiscovered = true;
                            potentialPaths[neighbor] = potentialPaths[coordinates].AddStep(neighbor);
                        }
                    }
                }

                if (!newCellDiscovered)
                {
                    break;
                }
            }

            return potentialPaths[arrival];
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
