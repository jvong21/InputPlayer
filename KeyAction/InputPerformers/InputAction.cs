using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputPerformers.Interface;
using InputActions.InputStrategies.Interface;

namespace InputActions.InputPerformers
{
    public class InputAction : IInputAction
    {
        private IInputStrategyFactory InputStrategyFactory;

        public InputAction(IInputStrategyFactory inputStrategyFactory)
        {
            InputStrategyFactory = inputStrategyFactory;
        }

        public void PeformInputs(InputQueue inputs)
        {
            while(inputs.Inputs.Count > 0)
            {
                Input input = inputs.Inputs.Dequeue(); 
                IInputStrategy inputStrategy = InputStrategyFactory.CreateInputStrategy(input);
                inputStrategy.PeformInput(); 
            }
        }

    }
}
