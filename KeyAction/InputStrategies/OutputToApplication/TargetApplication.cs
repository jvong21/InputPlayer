using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace InputActions.InputStrategies.OutputToApplication
{
    internal class TargetSnesApplication
    {
        #region USER32dll

        // Activate an application window.
        [DllImport("USER32.DLL")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        #endregion

        internal static Process[] Snes9XProcesses => Process.GetProcessesByName("snes9x-x64");


        internal static void FocusOnTargetApplication()
        {
            IntPtr snes9x = GetTopSnes9XHandle();
            SetForegroundWindow(snes9x);
        }


        internal static bool ApplicationIsActivated()
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
