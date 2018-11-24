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
        private static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
        

        #endregion

        public static Process[] Snes9XProcesses => Process.GetProcessesByName("snes9x-x64");


        public static void FocusOnTargetApplication()
        {
            IntPtr snes9x = GetTopSnes9XHandle();
            SetForegroundWindow(snes9x);
        }
        

        public static bool ApplicationIsActivated()
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            if (foregroundWindow == IntPtr.Zero)
            {
                return false;       // No window is currently activated
            }
            return foregroundWindow == GetTopSnes9XHandle();
        }

        private static IntPtr GetTopSnes9XHandle()
        {
            if (Snes9XProcesses.Length > 0)
            {
                Process snes9x = Snes9XProcesses[0];
                if (snes9x != null)
                {
                    return snes9x.MainWindowHandle;
                }
            }

            throw new System.Exception("Snes9X is not running"); 
        }

        
    }
}
