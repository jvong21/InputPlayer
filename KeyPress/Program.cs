using InputActions.Data;
using InputActions.InputCollectors.Collectors;
using InputActions.InputCollectors.Interface;
using InputActions.InputPerformers;
using InputActions.InputStrategies.ConsoleInput;
using InputActions.InputStrategies.ExternalInputApi;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using InputActions.InputStrategies.Interface;
using InputActions.InputStrategies.OutputToApplication;
using System;

namespace KeyPress
{
    class Program
    {
        static void Main(string[] args)
        {
            ExternalApplicationOutput(); 
        }

        public static void ConsoleInput()
        {
            // Collect inputs 
            IInputCollector inputCollector = new ConsoleInputDownCollectorWithDelays();
            InputQueue inputs = inputCollector.GenerateInputs();

            // Perform the inputs
            IInputStrategyFactory inputStrategyFactory = new ConsoleInputStrategyFactory();
            InputAction inputAction = new InputAction(inputStrategyFactory);
            Console.WriteLine("--Writing Input From Keyboard to Keyboard--");
            inputAction.PeformInputs(inputs);
        }

        public static void ExternalApplicationOutput()
        {
            // Collect inputs 
            IInputCollector inputCollector = new ConsoleInputDownCollectorWithDelays();
            InputQueue inputs = inputCollector.GenerateInputs();

            // Inputs to calculator
            IExternalInputApiWrapper externalInputApi = new InputSimulatorApi(); 
            IInputStrategyFactory inputStrategyFactory = new InputToApplicationStrategyFactory(externalInputApi);
            InputAction inputAction = new InputAction(inputStrategyFactory);
            inputAction.PeformInputs(inputs); 
        }
    }
}
