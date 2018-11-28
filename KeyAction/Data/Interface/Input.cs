using System.Runtime.Serialization;

namespace InputActions.Data.Interface
{
    [DataContract]
    public abstract class Input
    {
        [DataMember]
        public string InputKey { get; private set; }

        [DataMember]
        public int InputDelayInMilliseconds { get; private set; }

        internal Input(string key, int inputDelay)
        {
            InputKey = key;
            InputDelayInMilliseconds = inputDelay;
        }

        
    }
}
