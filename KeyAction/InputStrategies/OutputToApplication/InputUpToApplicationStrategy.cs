using InputActions.Data.Interface;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using System.Threading;

namespace InputActions.InputStrategies.OutputToApplication
{
    internal class InputUpToApplicationStrategy : InputToApplicationStrategy
    {
        public InputUpToApplicationStrategy(Input input, IExternalInputApiWrapper externalInputApi): base(input, externalInputApi)
        {
        }

        protected internal override void PerformInput_Internal()
        {
            Thread.Sleep(Input.InputDelayInMilliseconds);
            InputSimulator.Keyboard_KeyUp(Input.InputKey);
        }
    }
}
