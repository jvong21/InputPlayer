using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputPerformers.Interface;
using InputActions.InputStrategies.Interface;
using InputActions.InputStrategies.OutputToApplication;
using System.Collections.Generic;
using System.Threading;

namespace InputActions.InputPerformers
{
    public class InputActionToApplication : IInputAction
    {
        private IInputStrategyFactory InputStrategyFactory;
        private readonly int WAIT_BEFORE_FOCUS = 1000; 
        private readonly int WAIT_BEFORE_INPUTTING_AGAIN = 2000; 

        public InputActionToApplication(IInputStrategyFactory inputStrategyFactory)
        {
            InputStrategyFactory = inputStrategyFactory;
        }

        public void PeformInputs(InputQueue inputs)
        {
            Thread.Sleep(WAIT_BEFORE_FOCUS); // Wait before focusing so console input is not confused with target application input
            TargetSnesApplication.FocusOnTargetApplication();
            Queue<Input> currentInputQueue = inputs.Inputs;
            Queue<Input> newInputQueue = new Queue<Input>(); 
            while (TargetSnesApplication.ApplicationIsActivated()) // While target is focused
            {
                Input input = currentInputQueue.Dequeue();
                IInputStrategy inputStrategy = InputStrategyFactory.CreateInputStrategy(input);
                inputStrategy.PeformInput();
                newInputQueue.Enqueue(input); 
                if(currentInputQueue.Count <= 0)
                {
                    RebuildInputQueue(newInputQueue, currentInputQueue); 
                }
            }
        }

        private void RebuildInputQueue(Queue<Input> newInputQueue, Queue<Input> currentInputQueue)
        {
            Thread.Sleep(WAIT_BEFORE_INPUTTING_AGAIN); // Wait before performing inputs again
            while (newInputQueue.Count > 0)
            {
                currentInputQueue.Enqueue(newInputQueue.Dequeue());
            }
        }

    }
}
