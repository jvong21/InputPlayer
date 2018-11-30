using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using System.Threading;

namespace InputActions.InputStrategies.OutputToApplication
{
    internal class InputHoldToApplicationStrategy : InputToApplicationStrategy
    {
        public InputHoldToApplicationStrategy(Input input, IExternalInputApiWrapper externalInputApi): base(input, externalInputApi)
        {
        }

        protected internal override void PerformInput_Internal()
        {
            InputHold currentHoldInput = CastToInputHold(); 
            Thread.Sleep(currentHoldInput.InputDelayInMilliseconds);
            InputSimulator.Keyboard_KeyDown(Input.InputKey);
            Thread.Sleep(currentHoldInput.HoldInMilliseconds);
            InputSimulator.Keyboard_KeyUp(currentHoldInput.InputKey); 
        }

        private InputHold CastToInputHold()
        {
            try
            {
                return this.Input as InputHold; 
            } 
            catch(System.Exception e)
            {
                throw new System.Exception("The current input cast to hold encountered an exception", e); 
            }
        }
    }
}
