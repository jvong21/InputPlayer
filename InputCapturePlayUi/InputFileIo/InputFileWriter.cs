using InputActions.Data;
using InputActions.Data.Interface;
using InputCapturePlayUi.InputFileIo.Error;
using InputCapturePlayUi.InputFileIo.Interface;
using System.IO;
using System.Runtime.Serialization.Json;

namespace InputCapturePlayUi.InputFileIo
{
    public class InputFileWriter : IInputFileWriter
    {
        public void WriteInputQueueToFile(IInputQueue inputQueue, string location)
        {
            InputQueue currentInputQueue = GetInputQueue(inputQueue); 
            string inputJsonString = CreateJsonInputQueue(currentInputQueue);
            WriteToFile(inputJsonString, location); 
        }

        private InputQueue GetInputQueue(IInputQueue inputQueue)
        {

            if(inputQueue.GetType() != typeof(InputQueue))
            {
                throw new InvalidInputQueueException(); 
            }

            return inputQueue as InputQueue;
        }

        private string CreateJsonInputQueue(InputQueue inputQueue)
        {
            string resultString = string.Empty; 
            using (MemoryStream inputMemoryStream = new MemoryStream())
            {
                DataContractJsonSerializer inputSerializer = new DataContractJsonSerializer(typeof(InputQueue));
                inputSerializer.WriteObject(inputMemoryStream, inputQueue);
                inputMemoryStream.Position = 0;
                using (StreamReader inputStreamReader = new StreamReader(inputMemoryStream))
                {
                    resultString = inputStreamReader.ReadToEnd();
                }
            }

            return resultString; 
        }

        private void WriteToFile(string jsonString, string location)
        {
            try
            {
                using (StreamWriter outputFileWriter = new StreamWriter(location))
                {
                    outputFileWriter.Write(jsonString);
                }
            }
            catch (IOException e)
            {
                throw new IOException("There was a problem with writing the file"); 
            }
            
        }
    }
}
