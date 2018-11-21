using InputActions.InputStrategies.ExternalInputApi.Interface;
using System;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace InputActions.InputStrategies.ExternalInputApi
{
    public class InputSimulatorApi: IExternalInputApiWrapper
    {
        private InputSimulator InputSimulator => new InputSimulator(); 


        public InputSimulatorApi()
        {

        }

        public void Keyboard_KeyDown(string key)
        {
            VirtualKeyCode keyCode = GetCleanVirtualKeyCode(key); 
            InputSimulator.Keyboard.KeyDown(keyCode);
        }

        public void Keyboard_KeyUp(string key)
        {
            VirtualKeyCode keyCode = GetCleanVirtualKeyCode(key);
            InputSimulator.Keyboard.KeyUp(keyCode); 
        }
        
        public void Keyboard_KeyPress(string key)
        {
            
            VirtualKeyCode keyCode = GetCleanVirtualKeyCode(key);

            // KeyPress doesn't seem to work, so replacing with KeyDown then KeyUp immediately to emulate a press
            // InputSimulator.Keyboard.KeyPress(keyCode);

            // This is inconsistent too
            InputSimulator.Keyboard.KeyDown(keyCode);
            Thread.Sleep(10); 
            InputSimulator.Keyboard.KeyUp(keyCode);
        }

        private VirtualKeyCode GetCleanVirtualKeyCode(string key)
        {
            string formattedKey = key.ToUpper();
            VirtualKeyCode cleanedKeyCode = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), $"VK_{formattedKey}");
            return cleanedKeyCode; 
        }
    }
}
