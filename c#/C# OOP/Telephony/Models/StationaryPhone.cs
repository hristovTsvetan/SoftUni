using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interfaces;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if(!number.All(c => char.IsDigit(c)))
            {
                throw new InvalidNumberException();
            }

            return $"Dialing... {number}";
        }
    }
}
