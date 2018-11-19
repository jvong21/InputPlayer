using InputActions.Data.Interface;

namespace KeyPress.KeyActions.Data
{
    public abstract class Input: IInput
    {
        public string InputKey { get; private set; }
        public int InputDelayInMilliseconds { get; private set; }

        internal Input(string key, int inputDelay)
        {
            InputKey = key;
            InputDelayInMilliseconds = inputDelay;
        }

    }
}
