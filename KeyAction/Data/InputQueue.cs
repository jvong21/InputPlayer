using InputActions.Data.Interface;
using System.Collections.Generic;

namespace InputActions.Data
{
    public class InputQueue: Queue<Input>, IInputQueue
    {
        public InputQueue(ICollection<Input> inputs): base(inputs)
        {
        }

        public InputQueue(): base()
        {

        }

        public new Input Dequeue()
        {
            return base.Dequeue(); 
        }

        public new void Enqueue(Input input)
        {
            base.Enqueue(input); 
        }
    }
}