using InputActions.Data.Interface;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace InputActions.Data
{

    [DataContract]
    [KnownType(typeof(Input))]
    [KnownType(typeof(InputDown))]
    [KnownType(typeof(InputUp))]
    [KnownType(typeof(InputPress))]
    [KnownType(typeof(InputHold))]
    public class InputQueue : Queue<Input>, IInputQueue
    {

        public InputQueue(IList<Input> inputs): base(inputs)
        {
        }

        public InputQueue(): base()
        {

        }
    }
}