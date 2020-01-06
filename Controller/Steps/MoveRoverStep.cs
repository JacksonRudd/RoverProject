using System.Collections.Generic;
using Business;
using Business.Results;
using Controller.StringManipulation;

namespace Controller.Steps
{
    public class MoveRoverStep : IWorkflowStep
    {
        private readonly Simulation _sim;
        private readonly Rover _rover;
        private readonly GetMovementsFromUserInput _getMovementsFromUserInput;

        public MoveRoverStep(Simulation sim, Rover rover)
        {
            this._sim = sim;
            this._rover = rover;
            _getMovementsFromUserInput = new GetMovementsFromUserInput();
        }

        public string ExplainStep()
        {
            return _rover.Name + " Movement Plan: ";
        }


        public StepResponse CommitStep(string input)
        {
            UserResponse<List<Movement>> response = _getMovementsFromUserInput.GetMovements(input);
            if (!response.Success) return new StepResponse(response.Message);
            MoveRoverResult moveRoverResult = _sim.TryMoveRover(response.Data, _rover);
            if (!moveRoverResult.IsSuccess()) return new StepResponse(moveRoverResult.ToString());
            return new StepResponse(new AddRover(_sim),  moveRoverResult.ToString());
        } 


    }
}