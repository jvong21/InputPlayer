using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputStrategies.Exception;
using InputActions.InputStrategies.Interface;
using System;

namespace InputActions.InputStrategies.ConsoleInput
{
    public class ConsoleInputStrategyFactory : IInputStrategyFactory
    {
        public IInputStrategy CreateInputStrategy(IInput input)
        {
            // TODO: Look up visitor pattern for this type of implementation 
            if(input is InputDown)
            {
                return new ConsoleDownInputStrategy(input);
            }

            throw new InputStrategyNotFoundException();
        }
    }
}
