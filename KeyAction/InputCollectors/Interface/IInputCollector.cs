using InputActions.Data;
using KeyPress.KeyActions.Data;
using System.Collections.Generic;

namespace InputActions.InputCollectors.Interface
{
    public interface IInputCollector
    {
        InputQueue GenerateInputs(); 
    }
}
