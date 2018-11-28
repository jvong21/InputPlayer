using InputActions.Data;
using InputActions.Data.Interface;
using InputCapturePlayUi.InputFileIo.Interface;
using System.IO;
using System.Runtime.Serialization.Json;

namespace InputCapturePlayUi.InputFileIo
{
    public class InputFileWriter : IInputFileWriter
    {
        public void WriteInputQueueToFile(IInputQueue inputQueue, string location)
        {
            // TODO: Add steps for error handling
            // Serialize to json 
            // If serialization error, throw error
            // serialization to string
            // Verify location is legit
            // Write to a new text file in location 
            string inputJsonString = string.Empty;
            InputQueue currentInputQueue = inputQueue as InputQueue;
            using (MemoryStream inputMemoryStream = new MemoryStream())
            {
                DataContractJsonSerializer inputSerializer = new DataContractJsonSerializer(typeof(InputQueue));
                inputSerializer.WriteObject(inputMemoryStream, currentInputQueue);
                inputMemoryStream.Position = 0;
                using (StreamReader inputStreamReader = new StreamReader(inputMemoryStream))
                {
                    inputJsonString = inputStreamReader.ReadToEnd();
                }
            }

            using(StreamWriter outputFileWriter = new StreamWriter(location))
            {
                outputFileWriter.Write(inputJsonString); 
            }
        }
    }
}
