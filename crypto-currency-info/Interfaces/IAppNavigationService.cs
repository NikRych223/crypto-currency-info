using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crypto_currency_info.Interfaces
{
    internal interface IAppNavigationService
    {
        void NavigateToCryptocurrency();
        void NavigateToCryptoInfo();
        void NavigateToDetailInfo();
        void NavigateToConvert();
    }
}
