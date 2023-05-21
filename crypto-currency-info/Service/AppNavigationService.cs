using crypto_currency_info.Interfaces;
using crypto_currency_info.Pages;
using System.Windows.Controls;

namespace crypto_currency_info.Service
{
    internal class AppNavigationService : IAppNavigationService
    {
        private readonly Frame _mainFrame;

        private readonly CryptocurrencyPage _cryptocurrencyPage;
        private readonly CryptoInfoPage _cryptoinfoPage;
        private readonly ConverterPage _converterPage;

        public AppNavigationService(Frame mainFrame)
        {
            _mainFrame = mainFrame;
            _cryptocurrencyPage = new CryptocurrencyPage();
            _cryptoinfoPage = new CryptoInfoPage();
            _converterPage = new ConverterPage();
        }

        public void NavigateToCryptocurrency()
        {
            _mainFrame.Navigate(_cryptocurrencyPage);
        }

        public void NavigateToCryptoInfo()
        {
            _mainFrame.Navigate(_cryptoinfoPage);
        }

        //public void NavigateToDetailInfo()
        //{
        //    _mainFrame.Navigate(new CryptoDetailInfoPage());
        //}

        public void NavigateToConvert()
        {
            _mainFrame.Navigate(_converterPage);
        }
    }
}
