namespace Controller
{
    public class StepResponse
    {
        public bool Success;
        public string Message;
        public IWorkflowStep NextStep;

        private StepResponse(bool success, string message, IWorkflowStep nextStep)
        {
            this.Success = success;
            this.Message = message;
            NextStep = nextStep;
        }

        public StepResponse(string errorMessage) : this(false, errorMessage, null)
        { }
        public StepResponse(IWorkflowStep next, string message) : this(true, message, next)
        { }
        public StepResponse(IWorkflowStep next) : this(true, "", next)
        { }

    }
}