using InputActions.Data;
using InputActions.Data.Interface;
using InputCapturePlayUi.InputFileIo.Interface;
using System.IO;
using System.Runtime.Serialization.Json;

namespace InputCapturePlayUi.InputFileIo
{
    public class InputFileReader : IInputFileReader
    {
        public IInputQueue CreateInputQueueFromFile(string fileLocation)
        {
            // TODO: Add steps for error handling
            // Get file from file location 
                // If location doesn't exist, throw an error 
            // Read as string
            // if empty, pass
            // Otherwise, seralize as IInputQueue
            // If errors during serialization, throw an error
            IInputQueue inputQueue = new InputQueue();

            using (StreamReader inputFileReader = new StreamReader(fileLocation))
            {
                DataContractJsonSerializer inputSerializer = new DataContractJsonSerializer(typeof(InputQueue));
                inputQueue = (InputQueue)inputSerializer.ReadObject(inputFileReader.BaseStream); 
            }

            return inputQueue; 
        }
    }
}
