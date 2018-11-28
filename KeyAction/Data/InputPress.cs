using InputActions.Data.Interface;
using System.Runtime.Serialization;

namespace InputActions.Data
{
    [DataContract]
    public class InputPress: Input
    {
        public InputPress(string key, int delayInMilliseconds): base(key, delayInMilliseconds)
        {

        }
    }
}
