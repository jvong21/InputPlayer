using InputActions.Data;
using InputActions.InputCollectors.Collectors;
using InputActions.InputCollectors.Interface;
using InputActions.InputPerformers;
using InputActions.InputStrategies.ConsoleInput;
using InputActions.InputStrategies.Interface;
using System;

namespace KeyPress
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleInput(); 
        }

        public static void ConsoleInput()
        {
            // Collect inputs 
            IInputCollector inputCollector = new ConsoleInputCollectorWithDelays();
            InputQueue inputs = inputCollector.GenerateInputs();

            // Perform the inputs
            IInputStrategyFactory inputStrategyFactory = new ConsoleInputStrategyFactory();
            InputAction inputAction = new InputAction(inputStrategyFactory);
            Console.WriteLine("--Writing Input From Keyboard to Keyboard--");
            inputAction.PeformInputs(inputs);
        }
    }
}
