using System.Collections.Generic;

namespace InputActions.Data.Interface
{
    public interface IInputQueue
    {
        Input Dequeue();
        void Enqueue(Input input); 
        int Count { get; }
    }
}
