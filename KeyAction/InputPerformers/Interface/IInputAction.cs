using InputActions.Data;
using InputActions.Data.Interface;

namespace InputActions.InputPerformers.Interface
{
    internal interface IInputAction
    {
        void PeformInputs(IInputQueue inputs);
    }
}
