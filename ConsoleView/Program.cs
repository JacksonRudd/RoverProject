using System;
using Controller;
using Controller.Steps;

namespace ConsoleView
{
    class Program
    {
        private static void Main()
        {
            IWorkflowStep currentStep = new CreateWorkflow();

            while (true)
            {
                Console.Write(currentStep.ExplainStep());
                
                StepResponse response = currentStep.CommitStep(Console.ReadLine());
                if (response.Success)
                {
                    Console.WriteLine(response.Message);
                    currentStep = response.NextStep;
                }
                else
                {
                    Console.WriteLine(response.Message);
                }
            }
        }
    }
}
