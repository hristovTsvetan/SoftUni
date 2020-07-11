using System;
using System.Collections.Generic;
using System.Text;
using Telephony.IO.Interfaces;

namespace Telephony.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        void IWriter.Write(string text)
        {
            Console.Write(text);
        }
    }
}
