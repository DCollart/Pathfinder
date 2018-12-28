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

            Dictionary<Coordinates, PotentialPath> potentialPaths = new Dictionary<Coordinates, PotentialPath>();

            foreach(var keyValue in _cells.Where(kv => kv.Value.Type != CellType.Block))
            {
                potentialPaths[keyValue.Key] = keyValue.Key == departure ? 
                    new PotentialPath() {
                        Path = Path.Create(Step.Create(departure)),
                        Explored = false 
                    } : null;
            }

            while (potentialPaths[arrival] == null)
            {
                var nextCellsToExplore = potentialPaths.Where(p => p.Value != null && !p.Value.Explored);
                if (!nextCellsToExplore.Any())
                {
                    break;
                }
                var minPathWeight = nextCellsToExplore.Min(c => c.Value.Path.Weight);
                var nextCellToExplore = nextCellsToExplore.First(c => c.Value.Path.Weight == minPathWeight);
                nextCellToExplore.Value.Explored = true;
                foreach (var neighbor in _cells[nextCellToExplore.Key].Coordinates.Surrounding)
                {
                    if (potentialPaths.ContainsKey(neighbor) && potentialPaths[neighbor] == null)
                    {
                        potentialPaths[neighbor] = new PotentialPath() {
                            Path = nextCellToExplore.Value.Path.AddStep(Step.Create(neighbor, _cells[neighbor].Weight)),
                            Explored = false
                        };
                    }
                }
            }

            return potentialPaths[arrival]?.Path;
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

        private class PotentialPath
        {
            public Path Path { get; set; }
            public bool Explored { get; set; }
        }
    }
}
