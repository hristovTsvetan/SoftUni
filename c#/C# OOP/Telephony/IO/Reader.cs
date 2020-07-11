using System;
using System.Collections.Generic;
using System.Text;
using Telephony.IO.Interfaces;

namespace Telephony.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
