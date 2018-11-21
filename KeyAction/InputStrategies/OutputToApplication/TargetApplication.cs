using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace InputActions.InputStrategies.OutputToApplication
{
    internal class TargetSnesApplication
    {
        #region From https://docs.microsoft.com/en-us/dotnet/framework/winforms/how-to-simulate-mouse-and-keyboard-events-in-code
        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        #endregion

        // Needs to be updated b/c process ID may change
        public static Process ZSNES => Process.GetProcessById(2980);


        public static void FocusOnTargetApplication()
        {
            if (ZSNES != null)
            {
                SetForegroundWindow(ZSNES.MainWindowHandle);
            }
            else
            {
                Console.WriteLine("application not running");
            }
        }

        const int thing = 00400000; 

        public static void InputSomething(string key)
        {
            SendMessage(ZSNES.MainWindowHandle, thing, 0, key); 
        }
    }
}
