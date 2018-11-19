using InputActions.Data.Interface;
using InputActions.InputStrategies.InputSimulatorApi;
using InputActions.InputStrategies.Interface;
using System.Threading.Tasks;

namespace InputActions.InputStrategies.OutputToApplication
{
    public class InputDownToApplicationStrategy : IInputStrategy
    {
        public IInput Input { get; private set; }
        private InputSimulatorApiWrapper InputSimulator => new InputSimulatorApiWrapper(); 

        public InputDownToApplicationStrategy(IInput input)
        {
            Input = input;
        }

        public void PeformInput()
        {
            TargetApplication.FocusOnTargetApplication(); 
            Task.Delay(Input.InputDelayInMilliseconds);
            InputSimulator.Keyboard_KeyDown(Input.InputKey); 
        }

    }
}
