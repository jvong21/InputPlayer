using InputActions.InputStrategies.InputSimulatorApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestKeyAction.ErrorHandling;

namespace TestKeyAction
{
    [TestClass]
    public class InputSimulatorApiWrapperTest: UnexpectedExceptionHandler
    {
        [TestMethod]
        public void KeyDown_Does_Not_Produce_Exception()
        {
            InputSimulatorApiWrapper inputSimulator = GetEmptyInputSimulatorApiWrapper();

            try
            {
                inputSimulator.Keyboard_KeyDown("a");
            }
            catch(Exception e)
            {
                Assert.Fail(GenerateUnexepctedExceptionMessage(e));
            }
        }

        [TestMethod]
        public void KeyUp_Does_Not_Produce_Exception()
        {
            InputSimulatorApiWrapper inputSimulator = GetEmptyInputSimulatorApiWrapper();

            try
            {
                inputSimulator.Keyboard_KeyUp("a");
            }
            catch (Exception e)
            {
                Assert.Fail(GenerateUnexepctedExceptionMessage(e));
            }
        }

        [TestMethod]
        public void KeyPress_Does_Not_Produce_Exception()
        {
            InputSimulatorApiWrapper inputSimulator = GetEmptyInputSimulatorApiWrapper();

            try
            {
                inputSimulator.Keyboard_KeyPress("a");
            }
            catch (Exception e)
            {
                Assert.Fail(GenerateUnexepctedExceptionMessage(e));
            }
        }

        [TestMethod]
        public void KeyPress_Produces_ArgumentException_When_Invalid_Key_Provided()
        {
            InputSimulatorApiWrapper inputSimulator = GetEmptyInputSimulatorApiWrapper();

            Action keyPressAction = delegate () { inputSimulator.Keyboard_KeyPress("AAFDAJKLDASJFKDASJKLFDSJAKL"); };

            Assert.ThrowsException<ArgumentException>(keyPressAction); 
        }

        private InputSimulatorApiWrapper GetEmptyInputSimulatorApiWrapper()
        {
            return new InputSimulatorApiWrapper(); 
        }
        
    }
}
