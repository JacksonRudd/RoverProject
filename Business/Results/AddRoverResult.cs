namespace Business.Results
{
    public class AddRoverResult
    {
        public readonly bool Success;
        public Rover Rover;
        public readonly LegalityOfMove _legality;

        public AddRoverResult(bool success, Rover rover, LegalityOfMove legality)
        {
            Success = success;
            Rover = rover;
            _legality = legality;
        }
    }
}