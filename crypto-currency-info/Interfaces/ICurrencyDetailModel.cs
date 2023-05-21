using crypto_currency_info.Models;
using System.Collections.Generic;

namespace crypto_currency_info.Interfaces
{
    internal interface ICurrencyDetailModel : ICurrencyModel
    {
        List<MarketModel> Markets { get; set; }
    }
}
