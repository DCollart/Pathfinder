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
                    builder.AppendLine(new string('X', width));
                }
                else
                {
                    for (int x = 0; x < width - 1; x++)
                    {
                        if ((x == 1 && y == 1) || (x == width - 2 && y == height - 2))
                        {
                            builder.Append("1");
                            continue;
                        }
                        if (x == 0 || x == width - 1)
                        {
                            builder.Append("X");
                        }

                        if (random.Next(0, 6) == 0)
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
