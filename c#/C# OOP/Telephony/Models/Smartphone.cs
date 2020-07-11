using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Exceptions;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if(url.Any(u => char.IsDigit(u)))
            {
                throw new InvalidUrlException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!number.All(c => char.IsDigit(c)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {number}";
        }
    }
}
