using System;

namespace InputActions.InputStrategies.Exception
{
    public class InputStrategyNotFoundException: ArgumentException
    {
        public override string Message => "An input strategy was not found for the provided Input type"; 
    }
}
