using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidUrlException : Exception
    {
        private const string ERR_MSG = "Invalid URL!";

        public InvalidUrlException()
            :base(ERR_MSG)
        {
        }

        public InvalidUrlException(string message)
            : base(message)
        {
        }
    }
}
