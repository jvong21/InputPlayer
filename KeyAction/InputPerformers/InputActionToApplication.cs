using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputPerformers.Interface;
using InputActions.InputStrategies.Interface;
using InputActions.InputStrategies.OutputToApplication;
using System.Threading;

namespace InputActions.InputPerformers
{
    public class InputActionToApplication : IInputAction
    {
        private IInputStrategyFactory InputStrategyFactory;

        public InputActionToApplication(IInputStrategyFactory inputStrategyFactory)
        {
            InputStrategyFactory = inputStrategyFactory;
        }

        public void PeformInputs(InputQueue inputs)
        {
            Thread.Sleep(1000); // Wait before focusing so console input is not confused with target application input
            TargetSnesApplication.FocusOnTargetApplication();
            while (inputs.Inputs.Count > 0)
            {
                Input input = inputs.Inputs.Dequeue(); 
                IInputStrategy inputStrategy = InputStrategyFactory.CreateInputStrategy(input);
                inputStrategy.PeformInput(); 
            }
        }

    }
}
