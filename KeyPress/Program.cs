using InputActions.Data;
using InputActions.InputCollectors.Collectors;
using InputActions.InputCollectors.Interface;
using InputActions.InputPerformers.Interface;
using InputActions.InputPerformers.Performers;
using KeyPress.KeyActions.Data;
using System;

namespace KeyPress
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // IInputCollector inputCollector = new ConsoleInputCollector();
            IInputCollector inputCollector = new ConsoleInputCollectorWithDelays();
            InputQueue inputs = inputCollector.GenerateInputs();
            IInputAction inputAction = new InputToKeyboard();
            Console.WriteLine("--Writing Input From Keyboard to Keyboard--"); 
            inputAction.PeformInputs(inputs); 
        }
    }
}
