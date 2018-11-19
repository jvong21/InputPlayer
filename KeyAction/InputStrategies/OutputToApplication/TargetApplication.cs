using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InputActions.InputStrategies.OutputToApplication
{
    internal class TargetApplication
    {
        #region From https://docs.microsoft.com/en-us/dotnet/framework/winforms/how-to-simulate-mouse-and-keyboard-events-in-code
        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        #endregion

        public static void FocusOnTargetApplication()
        {
            // Get a handle to the Calculator application. The window class
            // and window name were obtained using the Spy++ tool.
            IntPtr targetApplicationHandle = FindWindow("CalcFrame", "Calculator");

            // Verify that Calculator is a running process.
            if (targetApplicationHandle == IntPtr.Zero)
            {
                throw new System.Exception("Application is not running"); 
            }

            SetForegroundWindow(targetApplicationHandle); 
        }
    }
}
