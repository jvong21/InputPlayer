using InputActions.Data.Interface;

namespace InputActions.Data
{
    public class InputHold : Input
    {
        public int HoldInMilliseconds { get; private set; }

        public InputHold(string key, int delayInMilliseconds) : base(key, delayInMilliseconds)
        {

        }

        public static InputHold CreateInputHoldWithHoldInMilliseconds(string key, int delayInMilliseconds, int holdInMilliseconds)
        {
            InputHold currentInputHold = new InputHold(key, delayInMilliseconds);
            currentInputHold.HoldInMilliseconds = holdInMilliseconds; 
            return currentInputHold; 
        }
    }
}
