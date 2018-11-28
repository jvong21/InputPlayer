using InputActions.Data.Interface;
using System.Runtime.Serialization;

namespace InputActions.Data
{
    [DataContract]
    public class InputUp : Input
    {
        public InputUp(string key, int delayInMilliseconds) : base(key, delayInMilliseconds)
        {

        }
    }
}
