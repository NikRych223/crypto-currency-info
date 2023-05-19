using crypto_currency_info.Service;
using crypto_currency_info.ViewModels;
using System.Windows.Controls;

namespace crypto_currency_info.Pages
{
    /// <summary>
    /// Interaction logic for CryptocurrencyPage.xaml
    /// </summary>
    public partial class CryptocurrencyPage : Page
    {
        public CryptocurrencyPage()
        {
            InitializeComponent();

            var currencyService = new CurrencyService();
            DataContext = new CryptocurrencyViewModel(currencyService);
        }
    }
}
