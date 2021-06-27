using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Exception
{
    public class InvalidSymbolException : SystemException
    {
        public string Symbol { get; set; }
        public InvalidSymbolException(string symbol)
        {
            Symbol = symbol;
        }
        public InvalidSymbolException(string symbol, string message) : base(message)
        {
            Symbol = symbol;

        }

        public InvalidSymbolException(string symbol, string message, System.Exception innerException) : base(message, innerException)
        {
            Symbol = symbol;

        }

    }
}
