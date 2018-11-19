using InputActions.Data.Interface;
using System.Collections.Generic;

namespace InputActions.Data
{
    public class InputQueue
    {
        public Queue<IInput> Inputs { get; private set;}

        public InputQueue(Queue<IInput> inputs)
        {
            Inputs = inputs; 
        }
    }
}