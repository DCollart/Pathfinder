using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathFinder.Shared
{
    public static class ListExtensions
    {
        public static List<T> Clone<T>(this List<T> source)
        {
            return source.Select(i => i).ToList();
        }
    }
}
