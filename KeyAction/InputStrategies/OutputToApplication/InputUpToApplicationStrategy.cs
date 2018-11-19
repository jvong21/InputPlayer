using InputActions.Data.Interface;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using InputActions.InputStrategies.Interface;
using System.Threading.Tasks;

namespace InputActions.InputStrategies.OutputToApplication
{
    public class InputUpToApplicationStrategy : IInputStrategy
    {
        public IInput Input { get; private set; }
        private IExternalInputApiWrapper InputSimulator;

        public InputUpToApplicationStrategy(IInput input, IExternalInputApiWrapper externalInputApi)
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
