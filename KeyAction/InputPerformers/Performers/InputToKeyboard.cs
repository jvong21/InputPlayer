using InputActions.Data;
using InputActions.InputPerformers.Interface;
using KeyPress.KeyActions.Data;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
using System;
using System.Threading.Tasks;
using InputActions.Data.Interface;

namespace InputActions.InputPerformers.Performers
{
    public class InputToKeyboard : IInputAction
    {

        private IInput currentInput;

        public void PeformInputs(InputQueue inputs)
        {
            while (inputs.Inputs.Count > 0)
            {
                this.currentInput = inputs.Inputs.Dequeue();
                var t = Task.Run(async delegate
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(currentInput.InputDelayInMilliseconds));
                    
                });
                try
                {
                    t.Wait();
                    SendKeys.SendWait(currentInput.InputKey);
                } catch(Exception e)

                {
                    // Bad things
                }
                
            }
        }
        

    }
}
