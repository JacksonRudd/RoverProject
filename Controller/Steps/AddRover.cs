using Business;
using Controller.StringManipulation;

namespace Controller.Steps
{
    public class AddRover: IWorkflowStep
    {
        private readonly Simulation _sim;
        private readonly GetRoverPositionFromUserInput _getRoverPositionFromUser;
        public AddRover(Simulation sim)
        {
            _getRoverPositionFromUser = new GetRoverPositionFromUserInput();
            this._sim = sim;
        }

        public string ExplainStep()
        {
            return  "Next Rover Starting Position: ";
        }
        public StepResponse CommitStep(string input)
        {
            var response = _getRoverPositionFromUser.GetRoverPostion(input);
            if (!response.Success) return new StepResponse(response.Message);
            var result =  _sim.AddRover(response.Data);
            return !result.Success ? new StepResponse(result._legality.ToString()) : new StepResponse(new MoveRoverStep(_sim, result.Rover));
        }
    }


}