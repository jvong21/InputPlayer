using InputActions.Data.Interface;
using InputActions.InputStrategies.ExternalInputApi;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using InputActions.InputStrategies.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace InputActions.InputStrategies.OutputToApplication
{
    public class InputDownToApplicationStrategy : IInputStrategy
    {
        public IInput Input { get; private set; }
        private IExternalInputApiWrapper InputSimulator;

        public InputDownToApplicationStrategy(IInput input, IExternalInputApiWrapper externalInputApi)
        {
            Input = input;
            InputSimulator = externalInputApi;
        }

        public void PeformInput()
        {
            TargetZsnesApplication.FocusOnTargetApplication();
            Thread.Sleep(Input.InputDelayInMilliseconds);
            InputSimulator.Keyboard_KeyPress(Input.InputKey);
        }

    }
}
