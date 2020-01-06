using System;

namespace Controller
{
    public interface IWorkflowStep
    {
        string ExplainStep();
        StepResponse CommitStep(string input);
    }
}