using System;
using Business;
using static System.Int32;

namespace Controller.StringManipulation
{
    public class GetCoordinatesFromUserInput
    {
        public UserResponse<Coordinate> GetCoordinateFromUserInput(string input)
        {
            try
            {
                var x = Parse(input.Split(' ')[0]);
                var y = Parse(input.Split(' ')[1]);
                return new UserResponse<Coordinate>(new Coordinate(x, y), true, "");

            }
            catch (Exception e)
            {
                return new UserResponse<Coordinate>(null, false, "cannot parse");
            }
        }
    }
}