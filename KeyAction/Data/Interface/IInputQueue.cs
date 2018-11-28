using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputActions.Data.Interface
{
    public interface IInputQueue
    {
        Input Dequeue();
        void Enqueue(Input input); 
        int Count { get; }
    }
}
