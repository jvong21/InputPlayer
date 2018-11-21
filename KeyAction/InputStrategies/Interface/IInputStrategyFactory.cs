using InputActions.Data.Interface;

namespace InputActions.InputStrategies.Interface
{
    public interface IInputStrategyFactory
    {
        IInputStrategy CreateInputStrategy(Input input); 
    }
}
