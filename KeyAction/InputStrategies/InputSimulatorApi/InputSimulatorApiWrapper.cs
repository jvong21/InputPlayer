using System;
using WindowsInput;
using WindowsInput.Native;

namespace InputActions.InputStrategies.InputSimulatorApi
{
    public class InputSimulatorApiWrapper
    {
        private InputSimulator InputSimulator => new InputSimulator(); 

        public InputSimulatorApiWrapper()
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
            InputSimulator.Keyboard.KeyPress(keyCode);
        }

        private VirtualKeyCode GetCleanVirtualKeyCode(string key)
        {
            string formattedKey = key.ToUpper();
            VirtualKeyCode cleanedKeyCode = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), $"VK_{formattedKey}");
            return cleanedKeyCode; 
        }
    }
}
