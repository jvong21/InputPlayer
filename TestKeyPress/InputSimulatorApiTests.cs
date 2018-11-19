/*
 * Tests InputSimulator: https://archive.codeplex.com/?p=inputsimulator 
 * 
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace TestKeyAction
{
    [TestClass]
    public class InputSimulatorApiTests
    {

        [TestMethod]
        public void Validate_InputSimulator_A_Key_IsKeyDown_Is_True_When_Down()
        {
            InputSimulator inputSimulator = Create_Empty_InputSimulator();
            inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_A);
            Assert.IsTrue(inputSimulator.InputDeviceState.IsKeyDown(WindowsInput.Native.VirtualKeyCode.VK_A)); 
        }

        [TestMethod]
        public void Validate_Input_Simulator_A_Key_IsKeyUp_Is_True_When_Down()
        {
            InputSimulator inputSimulator = Create_Empty_InputSimulator();
            Assert.IsTrue(inputSimulator.InputDeviceState.IsKeyUp(WindowsInput.Native.VirtualKeyCode.VK_A));
        }

        [TestMethod]
        public void Validate_InputSimulator_A_Key_IsKeyDown_Is_False_When_Not_Down()
        {
            InputSimulator inputSimulator = Create_Empty_InputSimulator();
            Assert.IsFalse(inputSimulator.InputDeviceState.IsKeyDown(WindowsInput.Native.VirtualKeyCode.VK_A));
        }

        [TestMethod]
        public void Validate_Input_Simulator_A_Key_IsKeyUp_Is_False_When_Not_Down()
        {
            InputSimulator inputSimulator = Create_Empty_InputSimulator();
            Assert.IsFalse(inputSimulator.InputDeviceState.IsKeyUp(WindowsInput.Native.VirtualKeyCode.VK_A));
        }

        private InputSimulator Create_Empty_InputSimulator()
        {
            InputSimulator inputSimulator = new InputSimulator();
            return inputSimulator; 
        }
    }
}
