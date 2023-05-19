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
        private readonly CurrencyService _currencyService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CurrencyModel> CurrencyModels { get; set; }

        public CryptocurrencyViewModel(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        private async void LoadDataFromApi()
        {
            var data = await _currencyService.GetTopCurrencies(5);

            var takedData = new ObservableCollection<CurrencyModel>();

            foreach (var currency in data)
            {
                takedData.Add((CurrencyModel)currency);
            }

            CurrencyModels = takedData;
            OnPropertyChanged("CurrencyModels");
        }

        public ICommand LoadDataFromApiCommand => new RelayCommand(LoadDataFromApi);

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
