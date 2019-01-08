using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinder.MapGenerator
{
    public class MapGenerator
    {
        public static string GenerateMap(int height, int width)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            for (int y = 0; y < height; y++)
            {
                if (y == 0 || y == height - 1)
                {
                    builder.Append(new string('X', width));
                    if (y == 0)
                    {
                        builder.Append(Environment.NewLine);
                    }
                }
                else
                {
                    for (int x = 0; x < width; x++)
                    {
                        if ((x == 1 && y == 1) || (x == width - 2 && y == height - 2))
                        {
                            builder.Append("1");
                        }
                        else if (x == 0 || x == width - 1)
                        {
                            builder.Append("X");
                        }
                        else if (random.Next(0, 6) == 0)
                        {
                            builder.Append("X");
                        }
                        else
                        {
                            int weight = random.Next(1, 10);
                            builder.Append(weight);
                        }                      
                    }
                    builder.Append(Environment.NewLine);
                }
            }

            return builder.ToString();
        }
    }
}
