using InputActions.Data;

namespace InputActions.InputCollectors.Interface
{
    public interface IInputCollector
    {
        InputQueue GenerateInputs(); 
    }
}
