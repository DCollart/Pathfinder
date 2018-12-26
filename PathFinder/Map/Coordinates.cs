using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinder.Map
{
    public class Coordinates
    {
        public int X { get; }
        public int Y { get; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinates Left => new Coordinates(X - 1, Y);

        public Coordinates Right => new Coordinates(X + 1, Y);

        public Coordinates Up => new Coordinates(X, Y - 1);

        public Coordinates Down => new Coordinates(X, Y + 1);

        public Coordinates[] Surrounding => new[] { Up, Right, Down, Left };


        public override bool Equals(object obj)
        {
            if (obj != null && obj is Coordinates other)
            {
                return Equals(this, other);
            }

            return false;
        }

        public static bool Equals(Coordinates first, Coordinates second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
            {
                return true;
            }
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            return first.X == second.X && first.Y == second.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * 11 +  Y.GetHashCode() * 7;
        }

        public static bool operator ==(Coordinates first, Coordinates second)
        {
            return Equals(first, second);
        }

        public static bool operator !=(Coordinates first, Coordinates second)
        {
            return !(Equals(first, second));
        }
    }
}
