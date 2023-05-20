using crypto_currency_info.Interfaces;
using crypto_currency_info.Pages;
using System.Windows.Controls;

namespace crypto_currency_info.Service
{
    internal class AppNavigationService : IAppNavigationService
    {
        private readonly Frame _mainFrame;

        public AppNavigationService(Frame mainFrame)
        {
            _mainFrame = mainFrame;
        }

        public void NavigateToCryptocurrency()
        {
            _mainFrame.Navigate(new CryptocurrencyPage());
        }

        public void NavigateToCryptoInfo()
        {
            _mainFrame.Navigate(new CryptoInfoPage());
        }

        public void NavigateToDetailInfo()
        {
            _mainFrame.Navigate(new CryptoDetailInfoPage());
        }
    }
}
