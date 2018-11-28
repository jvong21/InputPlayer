using Microsoft.VisualStudio.TestTools.UnitTesting;
using InputActions.InputCollectors.Interface;
using InputActions.Data;
using System.Collections.Generic;
using InputActions.Data.Interface;

namespace TestKeyAction
{
    [TestClass]
    public class InputCollectorInterfaceTests
    {

        [TestMethod]
        public void Test_TestInputCollector_Returns_Correct_Collection()
        {
            int correctNumberOfInputs = 5; 
            TestInputCollector testInputCollector = new TestInputCollector(correctNumberOfInputs);
            IInputQueue genereatedInputQueueFromTest = testInputCollector.GenerateInputs(); 
            Assert.AreEqual(correctNumberOfInputs, genereatedInputQueueFromTest.Count);
        }

        [TestMethod]
        public void Test_TestInputCollector_Returns_Correct_Collection_Compared_To_Incorrect_Count()
        {
            int correctNumberOfInputs = 5;
            int differentNumberOfInputs = 4; 
            TestInputCollector testInputCollector = new TestInputCollector(correctNumberOfInputs);
            IInputQueue genereatedInputQueueFromTest = testInputCollector.GenerateInputs();
            Assert.AreNotEqual(differentNumberOfInputs, genereatedInputQueueFromTest.Count);
        }

        internal class TestInputCollector : IInputCollector
        {
            private int numberOfDummyInputs; 

            public TestInputCollector(int numberOfDummyInputs)
            {
                this.numberOfDummyInputs = numberOfDummyInputs; 
            }

            public IInputQueue GenerateInputs()
            {
                IInputQueue inputs = GenerateDummyInputs();
                return inputs;
            }

            private IInputQueue GenerateDummyInputs()
            {
                IInputQueue dummyInputs = new InputQueue();
                for(int i = 1; i <= numberOfDummyInputs; i++)
                {
                    Input inputA = new InputDown("A", 0);
                    dummyInputs.Enqueue(inputA); 
                }
                return dummyInputs;
            }
        }

    }
}
