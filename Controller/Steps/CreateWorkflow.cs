using Business;
using Controller.StringManipulation;

namespace Controller.Steps
{
    public class CreateWorkflow:IWorkflowStep
    {

        private readonly GetCoordinatesFromUserInput _getCoordinatesFromUser;

        public CreateWorkflow()
        {
            _getCoordinatesFromUser = new GetCoordinatesFromUserInput();
        }

        public string ExplainStep()
        {
            return "Enter Graph Upper Right Coordinate:"; 
        }

        public StepResponse CommitStep(string input)
        {
            var response = _getCoordinatesFromUser.GetCoordinateFromUserInput(input);
            if(!response.Success) return new StepResponse(response.Message);
            if(response.Data.X < 0 || response.Data.Y < 0) return new StepResponse("coordinates cant be less than 0");
            var sim = new Simulation(response.Data);
            return new StepResponse(new AddRover(sim));
        }
    }


}