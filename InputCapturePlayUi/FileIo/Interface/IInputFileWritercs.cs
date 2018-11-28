using InputActions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCapturePlayUi.FileIo.Interface
{
    public interface IInputFileWriter
    {
        void WriteInputQueueToFile(InputQueue inputQueue); 
    }
}
