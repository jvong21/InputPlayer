using InputActions.InputStrategies.ExternalInputApi.Interface;
using InputActions.InputStrategies.OutputToApplication;
using System;
using System.Runtime.InteropServices;

namespace InputActions.InputStrategies.ExternalInputApi
{
    public class SendMessageApi : IExternalInputApiWrapper
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        public SendMessageApi()
        {

        }

        public void Keyboard_KeyDown(string key)
        {
            
        }

        public void Keyboard_KeyUp(string key)
        {
        }
        
        public void Keyboard_KeyPress(string key)
        {
            TargetZsnesApplication.InputSomething(key);
        }
        
    }
}
