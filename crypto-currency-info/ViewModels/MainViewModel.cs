using CommunityToolkit.Mvvm.Input;
using crypto_currency_info.Service;
using System.Windows.Input;

namespace crypto_currency_info.ViewModels
{
    internal class MainViewModel
    {
        private readonly AppNavigationService _navigationService;

        public MainViewModel(AppNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private void GoToCryptocurrencyPage()
        {
            _navigationService.NavigateToCryptocurrency();
        }

        private void GoToCryptoInfoPage()
        {
            _navigationService.NavigateToCryptoInfo();
        }

        //private void GoToCryptoDetailInfoPage()
        //{
        //    _navigationService.NavigateToDetailInfo();
        //}

        private void GoToCryptoConvertPage()
        {
            _navigationService.NavigateToConvert();
        }

        public ICommand GoToCryptocurrencyPageCommand => new RelayCommand(GoToCryptocurrencyPage);
        public ICommand GoToCryptoInfoPageCommand => new RelayCommand(GoToCryptoInfoPage);
        //public ICommand GoToCryptoDetailInfoPageCommand => new RelayCommand(GoToCryptoDetailInfoPage);
        public ICommand GoToConvertPageCommand => new RelayCommand(GoToCryptoConvertPage);
    }
}
