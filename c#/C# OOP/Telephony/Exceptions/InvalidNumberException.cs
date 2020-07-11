using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidNumberException : Exception
    {
        private const string ERR_MSG = "Invalid number!";

        public InvalidNumberException()
            :base(ERR_MSG)
        {

        }

        public InvalidNumberException(string message)
            : base(message)
        {
        }
    }
}
