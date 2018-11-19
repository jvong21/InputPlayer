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
            InputQueue genereatedInputQueueFromTest = testInputCollector.GenerateInputs(); 
            Assert.AreEqual(correctNumberOfInputs, genereatedInputQueueFromTest.Inputs.Count);
        }

        [TestMethod]
        public void Test_TestInputCollector_Returns_Correct_Collection_Compared_To_Incorrect_Count()
        {
            int correctNumberOfInputs = 5;
            int differentNumberOfInputs = 4; 
            TestInputCollector testInputCollector = new TestInputCollector(correctNumberOfInputs);
            InputQueue genereatedInputQueueFromTest = testInputCollector.GenerateInputs();
            Assert.AreNotEqual(differentNumberOfInputs, genereatedInputQueueFromTest.Inputs.Count);
        }

        internal class TestInputCollector : IInputCollector
        {
            private int numberOfDummyInputs; 

            public TestInputCollector(int numberOfDummyInputs)
            {
                this.numberOfDummyInputs = numberOfDummyInputs; 
            }

            public InputQueue GenerateInputs()
            {
                Queue<IInput> inputs = GenerateDummyInputs();
                InputQueue inputQueue = new InputQueue(inputs);
                return inputQueue;
            }

            private Queue<IInput> GenerateDummyInputs()
            {
                Queue<IInput> dummyInputs = new Queue<IInput>();
                for(int i = 1; i <= numberOfDummyInputs; i++)
                {
                    IInput inputA = new InputDown("A", 0);
                    dummyInputs.Enqueue(inputA); 
                }
                return dummyInputs;
            }
        }

    }
}
