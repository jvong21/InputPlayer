using InputActions.Data.Interface;
using System.Collections.Generic;

namespace InputActions.Data
{
    public class InputQueue
    {
        public Queue<Input> Inputs { get; private set;}

        public InputQueue(Queue<Input> inputs)
        {
            Inputs = inputs; 
        }
    }
}