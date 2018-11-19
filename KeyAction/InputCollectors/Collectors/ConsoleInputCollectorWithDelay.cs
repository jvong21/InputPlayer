using InputActions.Data;
using InputActions.InputCollectors.Interface;
using KeyPress.KeyActions.Data;
using System;
using System.Collections.Generic;

namespace InputActions.InputCollectors.Collectors
{
    public class ConsoleInputCollectorWithDelays : IInputCollector
    {
        public InputQueue GenerateInputs()
        {
            string inputString = ReadString();
            IList<string> inputsWithDelays = GenerateInputListWithDelays(inputString); 
            Queue<Input> inputQueue = BuildInputQueue(inputsWithDelays);
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

        private Queue<Input> BuildInputQueue(IList<string> inputs)
        {
            try
            {
                Queue<Input> finalInputQueue = new Queue<Input>();
                for (int i = 0; i < inputs.Count; i++)
                {
                    string[] inputAndDelay = inputs[i].Split('-');
                    int delay = int.Parse(inputAndDelay[1]); 
                    finalInputQueue.Enqueue(Input.GenerateInputWithDelayInMilliseconds(inputAndDelay[0], delay));
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
