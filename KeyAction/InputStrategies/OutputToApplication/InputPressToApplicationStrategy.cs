using InputActions.Data.Interface;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using System.Threading;

namespace InputActions.InputStrategies.OutputToApplication
{
    public class InputPressToApplicationStrategy : InputToApplicationStrategy
    {
        public InputPressToApplicationStrategy(Input input, IExternalInputApiWrapper externalInputApi): base(input, externalInputApi)
        {
        }

        protected override void PerformInput_Internal()
        {
            Thread.Sleep(Input.InputDelayInMilliseconds);
            InputSimulator.Keyboard_KeyPress(Input.InputKey);
        }
    }
}
