using InputActions.Data;
using InputActions.Data.Interface;

namespace InputCapturePlayUi.Data
{
    public class InputTypeToInputActionTypeFactory
    {
        public Input CreateInputFromFormsInputType(FormsInputTypes inputType, string key, int delay, int hold)
        {
            Input currentInput;

            switch (inputType)
            {
                case FormsInputTypes.Press:
                    currentInput = new InputPress(key, delay);
                    break;
                case FormsInputTypes.Charge:
                    currentInput = InputHold.CreateInputHoldWithHoldInMilliseconds(key, delay, hold);
                    break;
                case FormsInputTypes.HoldDown:
                    currentInput = new InputDown(key, delay);
                    break;
                case FormsInputTypes.Release:
                    currentInput = new InputUp(key, delay);
                    break;
                default:
                    throw new System.ArgumentException($"The inputType, {inputType.ToString()}, is not supported.");
            }

            return currentInput;
        }
    }
}
