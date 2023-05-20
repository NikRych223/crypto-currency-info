using CommunityToolkit.Mvvm.Input;
using crypto_currency_info.Interfaces;
using crypto_currency_info.Models;
using crypto_currency_info.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace crypto_currency_info.ViewModels
{
    class CryptoInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly CurrencyService _currencyService;

        private string _inputText;
        public string InputText
        {
            get
            {
                return _inputText;
            }

            set
            {
                _inputText = value;
                OnPropertyChanged(nameof(InputText));
            }
        }

        public ObservableCollection<CurrencyModel> CurrencyModels { get; set; }

        public CryptoInfoViewModel(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        private async void OnSearch()
        {
            var cryptoData = await _currencyService.GetCurrencieBySymbol(InputText);
            var dataListForView = new ObservableCollection<CurrencyModel>();

            foreach (var item in cryptoData)
            {
                dataListForView.Add((CurrencyModel)item);
            }

            CurrencyModels = dataListForView;
            OnPropertyChanged("CurrencyModels");
            InputText = string.Empty;
        }

        public ICommand OnSearchCommand => new RelayCommand(OnSearch);

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
