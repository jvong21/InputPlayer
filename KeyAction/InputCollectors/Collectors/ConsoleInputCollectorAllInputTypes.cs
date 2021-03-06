﻿using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputCollectors.Interface;
using System;
using System.Collections.Generic;

namespace InputActions.InputCollectors.Collectors
{
    public class ConsoleInputCollectorAllInputTypes : IInputCollector
    {
        public IInputQueue GenerateInputs()
        {
            string inputString = ReadString();
            IList<string> inputsWithDelays = GenerateInputListWithDelays(inputString);
            IInputQueue inputQueue = BuildInputQueue(inputsWithDelays);
            return inputQueue;
        }

        private string ReadString()
        {
            Console.WriteLine("=== Specify input key with type and delay in ms ===");
            Console.WriteLine("=== Example: A-PRESS-100 B-HOLD-100-100 [fourth option is hold duration] C-KEYUP-100 D-KEYDOWN-100 ===");
            string input = Console.ReadLine();
            return input;
        }

        private IList<string> GenerateInputListWithDelays(string inputString)
        {
            IList<string> inputs = new List<string>();

            inputs = inputString.Trim().Split(' '); 

            return inputs; 
        }

        private IInputQueue BuildInputQueue(IList<string> inputs)
        {
            try
            {
                IInputQueue finalInputQueue = new InputQueue();
                for (int i = 0; i < inputs.Count; i++)
                {
                    string[] inputParts = inputs[i].Split('-');
                    Input newInput = CreateInput(inputParts); 
                    finalInputQueue.Enqueue(newInput);
                }

                return finalInputQueue;
            }
            catch (Exception e)
            {
                throw new Exception("Error adding keys to keystroke collection.", e);
            }
        }

        private Input CreateInput(string[] inputParts)
        {
            
            string key = inputParts[0];
            string inputType = inputParts[1].ToLower();
            int delay = int.Parse(inputParts[2]);
            
            switch(inputType)
            {
                case ("press"):
                    return new InputPress(key, delay);
                case ("hold"):
                    int hold = int.Parse(inputParts[3]);
                    return InputHold.CreateInputHoldWithHoldInMilliseconds(key, delay, hold);
                case ("keyup"):
                    return new InputUp(key, delay);
                default:
                    return new InputDown(key, delay);
            }
        }
    }
}
