
namespace Business
{
    public class Rover
    {
        public readonly string Name;
        public Direction CurrentDirection;


        public Rover(string name, Direction currentDirection)
        {
            Name = name;
            CurrentDirection = currentDirection;
        }

        public void Left()
        {
            switch (CurrentDirection)
            {
                case Direction.North:
                    CurrentDirection = Direction.West;
                    break;
                case Direction.West:
                    CurrentDirection = Direction.South;
                    break;
                case Direction.South:
                    CurrentDirection = Direction.East;
                    break;
                case Direction.East:
                    CurrentDirection = Direction.North;
                    break;

            }
        }

        public void Right()
        {
            switch (CurrentDirection)
            {
                case Direction.North:
                    CurrentDirection = Direction.East;
                    break;
                case Direction.East:
                    CurrentDirection = Direction.South;
                    break;
                case Direction.South:
                    CurrentDirection = Direction.West;
                    break;
                case Direction.West:
                    CurrentDirection = Direction.North;
                    break;

            }
        }

    }
}
