using crypto_currency_info.Interfaces;
using System.Collections.Generic;

namespace crypto_currency_info.Models
{
    class CurrencyDetailModel : CurrencyModel, ICurrencyDetailModel
    {
        public List<MarketModel> Markets { get; set; }
    }
}
