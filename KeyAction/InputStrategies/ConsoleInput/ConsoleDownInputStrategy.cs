using InputActions.Data.Interface;
using InputActions.InputStrategies.Interface;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputActions.InputStrategies.ConsoleInput
{
    public class ConsoleDownInputStrategy : IInputStrategy
    {
        public Input Input { get; private set; }

        public ConsoleDownInputStrategy(Input input)
        {
            Input = input; 
        } 

        public void PeformInput()
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(TimeSpan.FromMilliseconds(Input.InputDelayInMilliseconds));

            });
            try
            {
                t.Wait();
                SendKeys.SendWait(Input.InputKey);
            }
            catch (System.Exception e)
            {
                // Bad things
            }
        }
    }
}
