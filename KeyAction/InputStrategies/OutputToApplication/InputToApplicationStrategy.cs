using InputActions.Data.Interface;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using InputActions.InputStrategies.Interface;

namespace InputActions.InputStrategies.OutputToApplication
{
    public abstract class InputToApplicationStrategy : IInputStrategy
    {
        public Input Input { get; private set; }
        protected IExternalInputApiWrapper InputSimulator;

        public InputToApplicationStrategy(Input input, IExternalInputApiWrapper externalInputApi)
        {
            Input = input;
            InputSimulator = externalInputApi;
        }

        public void PeformInput()
        {
            PerformInput_Internal(); 
        }

        protected abstract void PerformInput_Internal(); 
    }
}
