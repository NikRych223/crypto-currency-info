using crypto_currency_info.Service;
using crypto_currency_info.ViewModels;
using System.Windows.Controls;

namespace crypto_currency_info.Pages
{
    /// <summary>
    /// Interaction logic for ConverterPage.xaml
    /// </summary>
    public partial class ConverterPage : Page
    {
        public ConverterPage()
        {
            InitializeComponent();

            var currencyService = new CurrencyService();
            var convertViewModel = new ConverterViewModel(currencyService);
            DataContext = convertViewModel;
        }
    }
}
