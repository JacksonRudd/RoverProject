using System.Collections.Generic;
using Business.Results;

namespace Business
{
    public class Simulation
    {
        private readonly CoordinatesAndRoverContext _context;

        public Simulation(Coordinate endOfBoard)
        {
            _context = new CoordinatesAndRoverContext(endOfBoard);
        }


        public AddRoverResult AddRover(NewRoverInput roverInput)
        {
            LegalityOfMove result = _context.LegalCoordinate(roverInput.Coordinate);
            if (!result.IsLegal()) return new AddRoverResult(false, null, result);
            var rover = new Rover("Rover " + (_context.GetTotalRovers() + 1), roverInput.Direction);
            _context.AddRover(rover, roverInput.Coordinate);
            return new AddRoverResult(true, rover, result);
        }
        public MoveRoverResult TryMoveRover(List<Movement> movements, Rover rover)
        {
            Coordinate startingPoint = _context.GetCoordinateByRover(rover);
            Direction startingDirection = rover.CurrentDirection;
            foreach (Movement movement in movements)
            {
                if (movement == Movement.Left) rover.Left();
                else if (movement == Movement.Right) rover.Right();
                else
                {
                    LegalityOfMove result = _context.TryMove(rover);
                    if (result.IsLegal()) continue;
                    ResetRoverOnBoard(rover, startingDirection, startingPoint);
                    return new MoveRoverResult(_context.GetCoordinateByRover(rover), rover, result);
                }
            }
            return new MoveRoverResult(_context.GetCoordinateByRover(rover),rover , new LegalityOfMove(false, false));
        }

        private void ResetRoverOnBoard(Rover rover, Direction startingDirection, Coordinate startingPoint)
        {
            rover.CurrentDirection = startingDirection;
            _context.Remove(rover);
            _context.AddRover(rover, startingPoint);
        }
    }
}