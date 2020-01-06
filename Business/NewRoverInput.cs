using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class NewRoverInput
    {
        public Direction Direction;
        public Coordinate Coordinate;

        public NewRoverInput(Direction direction, Coordinate coordinate)
        {
            Direction = direction;
            Coordinate = coordinate;
        }
    }
}
