using InputActions.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestInputQueue
{
    [TestClass]
    public class InputQueueTests
    {



        [TestMethod]
        public void Dequeue_Removes_Front_And_New_Front_Is_Previous_Item()
        {
            InputQueue testInputQueue = Create_Input_Queue_Two_Items();
            testInputQueue.Dequeue();
            Assert.IsTrue(testInputQueue.Peek().InputDelayInMilliseconds.Equals(1) && testInputQueue.Peek().InputKey.Equals("b"));
        }

        [TestMethod]
        public void Enqueue_Returns_Correct_Count()
        {
            InputQueue testInputQueue = Create_Input_Queue_Two_Items();
            testInputQueue.Enqueue(new InputDown("b", 1));

            Assert.IsTrue(testInputQueue.Count == 3); 
        }

        private InputQueue Create_Input_Queue_Two_Items()
        {
            InputQueue inputQueue = new InputQueue();
            inputQueue.Enqueue(new InputDown("a", 1));
            inputQueue.Enqueue(new InputDown("b", 1));
            return inputQueue; 
        }

    }
}
