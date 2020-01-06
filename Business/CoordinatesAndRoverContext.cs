using System.Collections.Generic;

namespace Business
{
    internal class CoordinatesAndRoverContext
    {
        private readonly Coordinate _rightCornerOfBoard;
        private readonly Dictionary<Coordinate, Rover> _cordToRovers;
        private readonly Dictionary<Rover, Coordinate> _roversToCords;

        public CoordinatesAndRoverContext(Coordinate rightCornerOfBoard)
        {
            _rightCornerOfBoard = rightCornerOfBoard;
            _cordToRovers = new Dictionary<Coordinate, Rover>();
            _roversToCords = new Dictionary<Rover, Coordinate>();
        }

        public Coordinate GetCoordinateByRover(Rover rover)
        {
            _roversToCords.TryGetValue(rover, out var cord);
            return cord;
        }


        public void AddRover(Rover rover, Coordinate startingPoint)
        {
            _roversToCords.Add(rover, startingPoint);
            _cordToRovers.Add(startingPoint, rover);
        }

        public bool CoordinateBiggerThanBoard(Coordinate currentCoordinate)
        {
            return currentCoordinate.X > _rightCornerOfBoard.X
                   || currentCoordinate.Y > _rightCornerOfBoard.Y
                   || 0 >currentCoordinate.X
                   || 0 > currentCoordinate.Y;
        }

        public LegalityOfMove TryMove(Rover rover)
        {

            var next = GetCoordinateByRover(rover).GetNext(rover.CurrentDirection);
            LegalityOfMove ans = LegalCoordinate(next);
            if (ans.IsLegal())
            {
                Remove(rover);
                AddRover(rover, next);
            }
            return ans;
        }

        public LegalityOfMove LegalCoordinate(Coordinate currentCoordinate)
        {


            return new LegalityOfMove(CoordinateBiggerThanBoard(currentCoordinate),
                GetRoverByCoordinate(currentCoordinate) != null);
        }

        public void Remove(Rover rover)
        {
            _cordToRovers.Remove(GetCoordinateByRover(rover));
            _roversToCords.Remove(rover);
        }
        public int GetTotalRovers()
        {
            return _roversToCords.Count;
        }

        public Rover GetRoverByCoordinate(Coordinate coordinate)
        {
            _cordToRovers.TryGetValue(coordinate, out var rover);
            return rover;

        }

    }
}