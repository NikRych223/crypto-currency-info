using System.Collections.Generic;

namespace crypto_currency_info.Models
{
    class CurrencyDetailModel : CurrencyModel
    {
        public List<MarketModel> Markets { get; set; }
    }
}
