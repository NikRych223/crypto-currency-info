using CommunityToolkit.Mvvm.Input;
using crypto_currency_info.Models;
using crypto_currency_info.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace crypto_currency_info.ViewModels
{
    class CryptocurrencyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly CurrencyService _currencyService;
        public ObservableCollection<CurrencyModel> CurrencyModels { get; set; }

        public CryptocurrencyViewModel(CurrencyService currencyService)
        {
            _currencyService = currencyService;
            LoadDataFromApi();
        }

        private async void LoadDataFromApi()
        {
            var data = await _currencyService.GetCurrenciesByLimit(10);

            var dataListForView = new ObservableCollection<CurrencyModel>();

            foreach (var currency in data)
            {
                dataListForView.Add((CurrencyModel)currency);
            }

            CurrencyModels = dataListForView;
            OnPropertyChanged("CurrencyModels");
        }

        public ICommand LoadDataFromApiCommand => new RelayCommand(LoadDataFromApi);

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
