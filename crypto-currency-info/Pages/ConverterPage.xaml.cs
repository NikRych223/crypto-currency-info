using crypto_currency_info.Service;
using crypto_currency_info.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
