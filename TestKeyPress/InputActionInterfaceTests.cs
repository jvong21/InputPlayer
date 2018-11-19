using Microsoft.VisualStudio.TestTools.UnitTesting;
using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputStrategies.Interface;
using InputActions.InputPerformers;
using InputActions.InputStrategies.Exception;
using System.Collections.Generic;
using System;
using TestKeyAction.ErrorHandling;

namespace TestKeyAction
{
    [TestClass]
    public class InputActionInterfaceTests : UnexpectedExceptionHandler
    {
        [TestMethod]
        public void InputAction_Runs_PerformInputs()
        {
            InputAction inputAction = Create_InputAction_With_TestInputDownStrategyFactory();
            InputQueue inputQueue = Create_InputQueue_With_DownInputs();
            
            // Tests that this runs without an exception. However, if there is an exception, it will be caught and the test will fail. 
            try
            {
                inputAction.PeformInputs(inputQueue);
            }
            catch(System.Exception e)
            {
                Assert.Fail(GenerateUnexepctedExceptionMessage(e));
            }
        }

        

        private InputAction Create_InputAction_With_TestInputDownStrategyFactory()
        {
            IInputStrategyFactory testStrategyFactory = CreateTestInputStrategyFactory_WithInputDownOnly();
            return new InputAction(testStrategyFactory);
        }

        private InputQueue Create_InputQueue_With_DownInputs()
        {
            Queue<IInput> inputQueue = new Queue<IInput>();
            IInput downInput = CreateTestInputDown_No_Input_Delay(); 
            inputQueue.Enqueue(downInput); 
            return new InputQueue(inputQueue); 
        }


        [TestMethod]
        public void InputStrategyFactory_Returns_TestInputDownStrategy_Type()
        {
            IInputStrategyFactory testStrategyFactory = CreateTestInputStrategyFactory_WithInputDownOnly();
            IInput inputDown = CreateTestInputDown_No_Input_Delay(); 
            IInputStrategy inputStrategy = testStrategyFactory.CreateInputStrategy(inputDown);

            Assert.IsInstanceOfType(inputStrategy, typeof(TestInputDownStrategy)); 
        }

        [TestMethod]
        public void InputStrategyFactory_Throws_InputStrategyNotFoundException()
        {
            IInputStrategyFactory testStrategyFactory = CreateTestInputStrategyFactory_WithInputDownOnly();
            IInput inputUp = CreateTestInputUp_No_Input_Delay();
            System.Action inputStrategyExecute = delegate() { testStrategyFactory.CreateInputStrategy(inputUp); };

            Assert.ThrowsException<InputStrategyNotFoundException>(inputStrategyExecute); 
        }

        private InputDown CreateTestInputDown_No_Input_Delay()
        {
            return new InputDown("a", 0);
        }

        private InputUp CreateTestInputUp_No_Input_Delay()
        {
            return new InputUp("a", 0);
        }

        private IInputStrategyFactory CreateTestInputStrategyFactory_WithInputDownOnly()
        {
            IInputStrategyFactory testInputStrategyFactory = new TestInputStrategyFactory();
            return testInputStrategyFactory; 
        }

        internal class TestInputDownStrategy : IInputStrategy
        {
            public IInput Input => new InputDown("a", 0);

            public void PeformInput()
            {
                // Do something 
            }
        }

        internal class TestInputStrategyFactory : IInputStrategyFactory
        {
            public IInputStrategy CreateInputStrategy(IInput input)
            {
                if(input is InputDown)
                {
                    return new TestInputDownStrategy(); 
                }

                throw new InputStrategyNotFoundException(); 
            }
        }

    }
}
