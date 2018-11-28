using InputActions.Data;
using InputActions.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCapturePlayUi.FileIo.Interface
{
    public interface IInputFileReader
    {
        InputQueue CreateInputQueueFromFile(string fileLocation); 
    }
}
