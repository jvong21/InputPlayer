using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace InputActions.InputStrategies.OutputToApplication
{
    internal class TargetZsnesApplication
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
        

        public static void FocusOnTargetApplication()
        {
            Process zsnes = Process.GetProcessById(9804);

            if(zsnes != null)
            {
                SetForegroundWindow(zsnes.MainWindowHandle);
            }
            else
            {
                Console.WriteLine("application not running");
            }
        }
    }
}
