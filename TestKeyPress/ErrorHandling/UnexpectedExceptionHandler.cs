using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKeyAction.ErrorHandling
{
    public abstract class UnexpectedExceptionHandler
    {
        public string GenerateUnexepctedExceptionMessage(System.Exception e)
        {
            return "Received an exception, although one was not expected: "
                + Environment.NewLine + e.Message
                + Environment.NewLine + e.StackTrace;
        }
    }
}
