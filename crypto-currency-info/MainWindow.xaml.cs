using crypto_currency_info.Service;
using crypto_currency_info.ViewModels;
using System.Windows;

namespace crypto_currency_info
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var appNavigationService = new AppNavigationService(mainFrame);
            appNavigationService.NavigateToCryptocurrency();
            DataContext = new MainViewModel(appNavigationService);
        }
    }
}
