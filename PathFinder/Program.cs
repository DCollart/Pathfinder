using PathFinder.Map;
using System;
using System.Linq;

namespace PathFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringMap = MapGenerator.MapGenerator.GenerateMap(30, 30);
            var map = MapLoader.MapLoader.LoadFromString(stringMap);

            var departure = new Coordinates(1, 1);
            var arrival = new Coordinates(28, 28);

            var path = map.FindPath(departure, arrival);
            DisplayMap(map, path);

            Console.ReadKey();
        }

        static void DisplayMap(Map.Map map, Path path)
        {
            if (path != null)
            {
                Console.WriteLine($"Path weight : {path.Weight}");
            }
            else
            {
                Console.WriteLine("No path found");
            }
            var cells = map.GetAllCells();
            var minX = cells.OrderBy(c => c.Key.X).First().Key.X;
            var maxX = cells.OrderByDescending(c => c.Key.X).First().Key.X;
            var minY = cells.OrderBy(c => c.Key.Y).First().Key.Y;
            var maxY = cells.OrderByDescending(c => c.Key.Y).First().Key.Y;

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    Coordinates coordinates = new Coordinates(x, y);
                    if (cells.ContainsKey(coordinates))
                    {
                        Cell cell = cells[coordinates];
                        if (cell.Type == CellType.Block)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" ");
                        }
                        else
                        {
                            if (path.Contains(coordinates))
                            {
                                Console.BackgroundColor = ConsoleColor.Green;                    
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                            }

                            Console.Write(coordinates == path.Arrival ? "A" : coordinates == path.Departure ? "D" : cell.Weight.ToString());
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
