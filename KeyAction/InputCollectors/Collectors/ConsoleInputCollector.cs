using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputCollectors.Interface;
using System;
using System.Collections.Generic;

namespace InputActions.InputCollectors.Collectors
{
    public class ConsoleInputCollector : IInputCollector
    {
        public IInputQueue GenerateInputs()
        {
            string inputString = ReadString();
            IInputQueue inputQueue = BuildInputStack(inputString);
            return inputQueue; 
        }

        private string ReadString()
        {
            Console.WriteLine("---Input a string---");
            string input = Console.ReadLine();
            return input;
        }

        private IInputQueue BuildInputStack(string input)
        {
            try
            {
                IInputQueue finalInputQueue = new InputQueue(); 
                for (int i = 0; i < input.Length; i++)
                {
                    finalInputQueue.Enqueue(new InputDown(input.Substring(i, 1), 0)); 
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
