using InputActions.Data;
using InputActions.InputCollectors.Interface;
using KeyPress.KeyActions.Data;
using System;
using System.Collections.Generic;

namespace InputActions.InputCollectors.Collectors
{
    public class ConsoleInputCollector : IInputCollector
    {
        public InputQueue GenerateInputs()
        {
            string inputString = ReadString();
            Queue<Input> inputQueue = BuildInputStack(inputString);
            InputQueue finalInputQueue = new InputQueue(inputQueue); 
            return finalInputQueue; 
        }

        private string ReadString()
        {
            Console.WriteLine("---Input a string---");
            string input = Console.ReadLine();
            return input;
        }

        private Queue<Input> BuildInputStack(string input)
        {
            try
            {
                Queue<Input> finalInputQueue = new Queue<Input>(); 
                for (int i = 0; i < input.Length; i++)
                {
                    finalInputQueue.Enqueue(Input.GenerateInput(input.Substring(i, 1))); 
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
