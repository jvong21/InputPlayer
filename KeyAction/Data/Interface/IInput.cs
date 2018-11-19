namespace InputActions.Data.Interface
{
    public interface IInput
    {
        string InputKey { get; }
        int InputDelayInMilliseconds { get; }
    }
}
