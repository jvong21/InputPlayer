namespace KeyPress.KeyActions.Data
{
    public class Input
    {

        public string InputKey { get; private set; }
        public int InputDelayInMilliseconds { get; private set; }

        public static Input GenerateInputWithDelayInMilliseconds(string key, int inputDelay)
        {
            return new Input(key, inputDelay); 
        }

        public static Input GenerateInput(string key)
        {
            return new Input(key, 0); 
        }

        private Input(string key, int inputDelay)
        {
            InputKey = key;
            InputDelayInMilliseconds = inputDelay;
        }

    }
}
