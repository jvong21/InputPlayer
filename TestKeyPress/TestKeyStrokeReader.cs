using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyPress.KeyActions.Data;
using InputActions.InputCollectors.Interface;
using InputActions.Data;
using System.Collections.Generic;

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
                Queue<Input> inputs = GenerateDummyInputs();
                InputQueue inputQueue = new InputQueue(inputs);
                return inputQueue;
            }

            private Queue<Input> GenerateDummyInputs()
            {
                Queue<Input> dummyInputs = new Queue<Input>();
                for(int i = 1; i <= numberOfDummyInputs; i++)
                {
                    Input inputA = Input.GenerateInput("A");
                    dummyInputs.Enqueue(inputA); 
                }
                return dummyInputs;
            }
        }

    }
}
