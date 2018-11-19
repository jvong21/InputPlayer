using InputActions.Data.Interface;
using InputActions.InputStrategies.InputSimulatorApi;
using InputActions.InputStrategies.Interface;
using System.Threading.Tasks;

namespace InputActions.InputStrategies.OutputToApplication
{
    public class InputUpToApplicationStrategy : IInputStrategy
    {
        public IInput Input { get; private set; }
        private InputSimulatorApiWrapper InputSimulator => new InputSimulatorApiWrapper(); 

        public InputUpToApplicationStrategy(IInput input)
        {
            Input = input;
        }

        public void PeformInput()
        {
            TargetApplication.FocusOnTargetApplication(); 
            Task.Delay(Input.InputDelayInMilliseconds);
            InputSimulator.Keyboard_KeyUp(Input.InputKey); 
        }

    }
}
