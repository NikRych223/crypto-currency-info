using System;

namespace crypto_currency_info.Exceptions
{
    internal class CurrencieNotFoundException : Exception
    {
        public CurrencieNotFoundException(string message) : base(message) { }
    }
}
