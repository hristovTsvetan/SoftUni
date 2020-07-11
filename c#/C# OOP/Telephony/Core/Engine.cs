using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.IO;
using Telephony.Models;
using Telephony.IO.Interfaces;
using Telephony.Exceptions;

namespace Telephony.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private Smartphone smartphone;
        private StationaryPhone stationPhone;

        private Engine()
        {
            smartphone = new Smartphone();
            stationPhone = new StationaryPhone();
        }

        public Engine(IReader rd, IWriter wr)
            : this()
        {
            this.reader = rd;
            this.writer = wr;
        }

        public void Run()
        {
            string[] phones = reader.ReadLine()
                .Split(' ')
                .ToArray();

            string[] urls = reader.ReadLine()
                .Split(' ')
                .ToArray();

            CallNumbers(phones);
            Browse(urls);

        }

        private void Browse(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    writer.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidUrlException iue)
                {
                    writer.WriteLine(iue.Message);
                }

            }
        }

        private void CallNumbers(string[] phones)
        {

            foreach (var number in phones)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        writer.WriteLine(smartphone.Call(number));
                    }
                    else if (number.Length == 7)
                    {
                        writer.WriteLine(stationPhone.Call(number));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException ine)
                {
                    writer.WriteLine(ine.Message);
                }

            }
        }
    }
}
