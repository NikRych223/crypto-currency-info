using CommunityToolkit.Mvvm.Input;
using crypto_currency_info.Interfaces;
using crypto_currency_info.Models;
using crypto_currency_info.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace crypto_currency_info.ViewModels
{
    class CryptoDetailInfoViewModel : INotifyPropertyChanged
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
        private ICurrencyDetailModel _currencyModel;
        public ICurrencyDetailModel CurrencyModel
        {
            get { return _currencyModel; }
            set
            {
                _currencyModel = value;
                OnPropertyChanged(nameof(CurrencyModel));
            }
        }

        public ObservableCollection<MarketModel> Markets { get; set; }

        public CryptoDetailInfoViewModel(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        private async void OnSearch()
        {
            var cryptoData = await _currencyService.GetOneCurrencieDetailBySymbol(InputText, 5);

            var marketList = new ObservableCollection<MarketModel>();

            foreach (var market in cryptoData.Markets)
            {
                marketList.Add(market);
            }

            Markets = marketList;
            CurrencyModel = cryptoData;
        }

        public ICommand OnSearchCommand => new RelayCommand(OnSearch);

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
