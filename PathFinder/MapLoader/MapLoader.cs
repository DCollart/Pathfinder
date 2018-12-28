using PathFinder.Map;

namespace PathFinder.MapLoader
{
    public static class MapLoader
    {
        public static Map.Map LoadFromFile(string filename)
        {
            return LoadFromString(System.IO.File.ReadAllText(filename));
        }

        public static Map.Map LoadFromString(string stringMap)
        {
            var map = new Map.Map();

            var rows = stringMap.Split("\n");

            for(int y = 0; y < rows.Length; y++)
            {
                for(int x = 0; x < rows[y].Length; x++)
                {
                    CellType type = rows[y][x] == 'X' ? CellType.Block : CellType.Classic;
                    int weight = 0;
                    if (type == CellType.Classic && int.TryParse(rows[y][x].ToString(), out int result))
                    {
                        weight = result;
                    }
                    map.AddCell(new Cell(type, new Coordinates(x, y), weight));
                }
            }

            return map;
        }
    }
}