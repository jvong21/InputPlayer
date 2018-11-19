using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputCollectors.Interface;
using System;
using System.Collections.Generic;

namespace InputActions.InputCollectors.Collectors
{
    public class ConsoleInputDownCollectorWithDelays : IInputCollector
    {
        public InputQueue GenerateInputs()
        {
            string inputString = ReadString();
            IList<string> inputsWithDelays = GenerateInputListWithDelays(inputString); 
            Queue<IInput> inputQueue = BuildInputQueue(inputsWithDelays);
            InputQueue finalInputQueue = new InputQueue(inputQueue);
            return finalInputQueue;
        }

        private string ReadString()
        {
            Console.WriteLine("---Input a string with delays in ms---");
            Console.WriteLine("---Example: i-400 j-500 k-600 ---");
            string input = Console.ReadLine();
            return input;
        }

        private IList<string> GenerateInputListWithDelays(string inputString)
        {
            IList<string> inputs = new List<string>();

            inputs = inputString.Split(' '); 

            return inputs; 
        }

        private Queue<IInput> BuildInputQueue(IList<string> inputs)
        {
            try
            {
                Queue<IInput> finalInputQueue = new Queue<IInput>();
                for (int i = 0; i < inputs.Count; i++)
                {
                    string[] inputAndDelay = inputs[i].Split('-');
                    int delay = int.Parse(inputAndDelay[1]); 
                    finalInputQueue.Enqueue(new InputDown(inputAndDelay[0], delay));
                }

                return finalInputQueue;
            }
            catch (Exception e)
            {
                throw new Exception("Error adding keys to keystroke collection.", e);
            }
        }
    }
}
