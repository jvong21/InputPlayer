namespace InputActions.Data.Interface
{
    public abstract class Input
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
