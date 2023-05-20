using crypto_currency_info.Service;
using crypto_currency_info.ViewModels;
using System.Windows.Controls;

namespace crypto_currency_info.Pages
{
    /// <summary>
    /// Interaction logic for CryptoInfoPage.xaml
    /// </summary>
    public partial class CryptoInfoPage : Page
    {
        public CryptoInfoPage()
        {
            InitializeComponent();

            var currencyService = new CurrencyService();
            var cryptoInfoViewModel = new CryptoInfoViewModel(currencyService);
            DataContext = cryptoInfoViewModel;
        }
    }
}
