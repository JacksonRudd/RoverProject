using System;
using Business;

namespace Controller.StringManipulation
{
    public class GetRoverPositionFromUserInput
    {
        public Direction Direction(char d)
        {
            Direction direction;
            if (d == 'N') direction = Business.Direction.North;
            else if (d == 'S') direction = Business.Direction.West;
            else if (d == 'E') direction = Business.Direction.East;
            else if (d == 'W') direction = Business.Direction.West;
            else throw new Exception();
            return direction;
        }
        public UserResponse<NewRoverInput> GetRoverPostion(string input)
        {

            int x;
            int y;
            char d;
            try
            {
                x = Int32.Parse(input.Split(' ')[0]);
                y = Int32.Parse(input.Split(' ')[1]);
                d = input.Split(' ')[2].ToCharArray()[0];
            }
            catch (Exception e)
            {
                return new UserResponse<NewRoverInput>(null , false,"cant parse input");
            }

            Direction direction;
            try
            {
                direction = Direction(d);
            }
            catch
            {
                return new UserResponse<NewRoverInput>(null, false, "cant parse direction");
            }
            return new UserResponse<NewRoverInput>(new NewRoverInput(direction, new Coordinate(x, y)), true, "" );
        }
    }


}