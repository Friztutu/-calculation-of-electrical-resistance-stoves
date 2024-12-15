using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Errors
{
    public class NotCorrectInputDataException : Exception
    {
        public NotCorrectInputDataException() { }

        public NotCorrectInputDataException(string message)
            : base(message) { }
    }
}
