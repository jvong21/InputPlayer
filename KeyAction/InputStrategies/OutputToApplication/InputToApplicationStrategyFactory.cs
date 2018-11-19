using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputStrategies.Exception;
using InputActions.InputStrategies.Interface;

namespace InputActions.InputStrategies.OutputToApplication
{
    public class InputToApplicationStrategyFactory : IInputStrategyFactory
    {
        public IInputStrategy CreateInputStrategy(IInput input)
        {
            if(input is InputDown)
            {
                return new InputDownToApplicationStrategy(input); 
            }

            if(input is InputUp)
            {
                return new InputUpToApplicationStrategy(input); 
            }

            throw new InputStrategyNotFoundException(); 
        }
    }
}
