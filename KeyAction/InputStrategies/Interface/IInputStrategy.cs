using InputActions.Data.Interface;

namespace InputActions.InputStrategies.Interface
{
    public interface IInputStrategy
    {
        Input Input { get; }
        void PeformInput(); 
    }
}
