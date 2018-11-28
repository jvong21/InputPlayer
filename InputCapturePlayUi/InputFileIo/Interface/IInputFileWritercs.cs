using InputActions.Data.Interface;

namespace InputCapturePlayUi.InputFileIo.Interface
{
    public interface IInputFileWriter
    {
        void WriteInputQueueToFile(IInputQueue inputQueue, string location); 
    }
}
