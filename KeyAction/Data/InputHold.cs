using InputActions.Data.Interface;
using System.Runtime.Serialization;

namespace InputActions.Data
{
    [DataContract]
    public class InputHold : Input
    {
        [DataMember]
        public int HoldInMilliseconds { get; private set; }

        public InputHold(string key, int delayInMilliseconds) : base(key, delayInMilliseconds)
        {

        }

        public static InputHold CreateInputHoldWithHoldInMilliseconds(string key, int delayInMilliseconds, int holdInMilliseconds)
        {
            InputHold currentInputHold = new InputHold(key, delayInMilliseconds);
            currentInputHold.HoldInMilliseconds = holdInMilliseconds; 
            return currentInputHold; 
        }
    }
}
