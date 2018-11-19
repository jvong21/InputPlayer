using InputActions.Data.Interface;

namespace InputActions.InputStrategies.Interface
{
    public interface IInputStrategy
    {
        IInput Input { get; }
        void PeformInput(); 
    }
}
