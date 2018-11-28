using InputActions.Data;
using InputActions.Data.Interface;

namespace InputActions.InputCollectors.Interface
{
    public interface IInputCollector
    {
        IInputQueue GenerateInputs(); 
    }
}
