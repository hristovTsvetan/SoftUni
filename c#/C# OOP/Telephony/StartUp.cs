using System;
using Telephony.Core;
using Telephony.IO.Interfaces;
using Telephony.IO;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader rd = new Reader();
            IWriter wr = new Writer();

            Engine engine = new Engine(rd, wr);
            engine.Run();
        }
    }
}
