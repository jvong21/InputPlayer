using System;

namespace InputCapturePlayUi.InputFileIo.Error
{
    internal class InvalidInputQueueException: ArgumentException
    {
        public override string Message
        {
            get
            {
                return "The input queue provided is not of type InputQueue."; 
            }
        }
    }
}
