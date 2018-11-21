using InputActions.Data.Interface;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using InputActions.InputStrategies.Interface;
using System.Threading;

namespace InputActions.InputStrategies.OutputToApplication
{
    public class InputDownToApplicationStrategy : IInputStrategy
    {
        public Input Input { get; private set; }
        private IExternalInputApiWrapper InputSimulator;

        public InputDownToApplicationStrategy(Input input, IExternalInputApiWrapper externalInputApi)
        {
            Input = input;
            InputSimulator = externalInputApi;
        }

        public void PeformInput()
        {
            TargetZsnesApplication.FocusOnTargetApplication();
            Thread.Sleep(Input.InputDelayInMilliseconds);
            InputSimulator.Keyboard_KeyDown(Input.InputKey);
        }

    }
}
