using crypto_currency_info.Service;
using crypto_currency_info.ViewModels;
using System.Windows.Controls;

namespace crypto_currency_info.Pages
{
    /// <summary>
    /// Interaction logic for CryptoDetailInfoPage.xaml
    /// </summary>
    public partial class CryptoDetailInfoPage : Page
    {
        public CryptoDetailInfoPage()
        {
            InitializeComponent();

            var currencyService = new CurrencyService();
            var cryptoDetailInfoViewModel = new CryptoDetailInfoViewModel(currencyService);
            DataContext = cryptoDetailInfoViewModel;
        }
    }
}
