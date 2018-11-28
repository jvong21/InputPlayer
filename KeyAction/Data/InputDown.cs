using InputActions.Data.Interface;
using System.Runtime.Serialization;

namespace InputActions.Data
{
    [DataContract]
    public class InputDown: Input
    {
        public InputDown(string key, int delayInMilliseconds): base(key, delayInMilliseconds)
        {

        }
    }
}
