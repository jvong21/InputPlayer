using InputActions.Data.Interface;

namespace InputCapturePlayUi.InputFileIo.Interface
{
    public interface IInputFileReader
    {
        IInputQueue CreateInputQueueFromFile(string fileLocation); 
    }
}
