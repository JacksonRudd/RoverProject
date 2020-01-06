namespace Business.Results
{
    public class MoveRoverResult
    {
        public readonly Coordinate _finalCord;
        public readonly Rover _rover;
        public readonly LegalityOfMove _legalityOfMove;

        public MoveRoverResult(Coordinate finalCord, Rover rover, LegalityOfMove legalityOfMove)
        {
            _finalCord = finalCord;
            _rover = rover;
            _legalityOfMove = legalityOfMove;
        }


        public override string ToString()
        {
            return IsSuccess() ? $"{_rover.Name} Output: {_finalCord.X} {_finalCord.Y} {_rover.CurrentDirection}" : _legalityOfMove.ToString();
        }

        public bool IsSuccess()
        {
            return _legalityOfMove.IsLegal();
        }
    }
}