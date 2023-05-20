using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crypto_currency_info.Exceptions
{
    internal class CurrencieNotFoundException : Exception
    {
        public CurrencieNotFoundException(string message) : base(message) { }
    }
}
