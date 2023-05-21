using crypto_currency_info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crypto_currency_info.Interfaces
{
    internal interface ICurrencyDetailModel : ICurrencyModel
    {
        List<MarketModel> Markets { get; set; }
    }
}
