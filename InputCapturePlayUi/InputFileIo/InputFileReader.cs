using InputActions.Data;
using InputActions.Data.Interface;
using InputCapturePlayUi.InputFileIo.Interface;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace InputCapturePlayUi.InputFileIo
{
    public class InputFileReader : IInputFileReader
    {
        public IInputQueue CreateInputQueueFromFile(string fileLocation)
        {
            IInputQueue inputQueue = new InputQueue();

            try
            {
                using (StreamReader inputFileReader = new StreamReader(fileLocation))
                {
                    DataContractJsonSerializer inputSerializer = new DataContractJsonSerializer(typeof(InputQueue));
                    inputQueue = (InputQueue)inputSerializer.ReadObject(inputFileReader.BaseStream);
                }
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException($"The file at {fileLocation} was not found.");
            }
            catch (DirectoryNotFoundException e)
            {
                throw new DirectoryNotFoundException($"The directory at {fileLocation} was not found.");
            }
            catch (Exception e)
            {
                throw new IOException("There was a problem with attempting to read the file.", e);
            }

            return inputQueue; 
        }
    }
}
