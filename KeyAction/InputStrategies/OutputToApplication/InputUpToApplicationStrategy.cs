using InputActions.Data.Interface;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using InputActions.InputStrategies.Interface;
using System.Threading.Tasks;

namespace InputActions.InputStrategies.OutputToApplication
{
    public class InputUpToApplicationStrategy : IInputStrategy
    {
        public Input Input { get; private set; }
        private IExternalInputApiWrapper InputSimulator;

        public InputUpToApplicationStrategy(Input input, IExternalInputApiWrapper externalInputApi)
        {
            Input = input;
            InputSimulator = externalInputApi;
        }

        public void PeformInput()
        {
            TargetZsnesApplication.FocusOnTargetApplication();
            Task.Delay(Input.InputDelayInMilliseconds);
            InputSimulator.Keyboard_KeyUp(Input.InputKey); 
        }

    }
}
