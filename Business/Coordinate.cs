using System;

namespace Business
{
    public class Coordinate
    {
        public readonly int X;
        public readonly int Y;

        protected bool Equals(Coordinate other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Coordinate) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Coordinate GetNext(Direction roverCurrentDirection)
        {
            switch (roverCurrentDirection)
            {
                case Direction.North:
                    return new Coordinate(X , Y+1);
                case Direction.West:
                    return new Coordinate(X -1, Y);
                case Direction.South:
                    return new Coordinate(X, Y - 1);
                case Direction.East:
                    return new Coordinate(X +1, Y);
            }
            throw new Exception();
        }
    }
}