using System;
using System.Collections.Generic;
using Business;

namespace Controller.StringManipulation
{
    public class GetMovementsFromUserInput
    {
        public UserResponse<List<Movement>> GetMovements(string input)
        {
            List<Movement> ans = new List<Movement>();
            foreach (char c in input)
            {
                try
                {
                    Movement m = Movement(c);
                    ans.Add(m);

                }
                catch (Exception)
                {
                    return new UserResponse<List<Movement>>(null, false, "Improper Character: " + c);
                }

            }

            return new UserResponse<List<Movement>>(ans, true, "");
        }
        internal Movement Movement(char c)
        {
            Movement movement;
            if (c == 'L') movement = Business.Movement.Left;
            else if (c == 'R') movement = Business.Movement.Right;
            else if (c == 'M') movement = Business.Movement.Move;
            else throw new Exception();
            return movement;
        }
    }
}