using CommunityToolkit.Mvvm.Input;
using crypto_currency_info.Interfaces;
using crypto_currency_info.Models;
using crypto_currency_info.Service;
using crypto_currency_info.Windows;
using System.Collections.Generic;
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
        private int _selectedValue;
        private List<string> _currencySymbols;
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
        public int SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if (value >= 0)
                {
                    _selectedValue = value;
                    OnPropertyChanged(nameof(SelectedValue));
                    OnValueSelected(value);
                }
            }
        }

        public ObservableCollection<ICurrencyModel> CurrencyModels { get; set; }

        public CryptoInfoViewModel(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        private async void OnSearch()
        {
            var cryptoData = await _currencyService.GetCurrencieBySymbol(InputText);
            var dataListForView = new ObservableCollection<ICurrencyModel>();
            var currencySymbols = new List<string>();

            foreach (var item in cryptoData)
            {
                dataListForView.Add(item);
                currencySymbols.Add(item.Symbol);
            }

            CurrencyModels = dataListForView;
            _currencySymbols = currencySymbols;

            OnPropertyChanged("CurrencyModels");
            InputText = string.Empty;
        }

        private void OnValueSelected(int selectedValue)
        {
            var criptoSymbol = _currencySymbols[selectedValue];

            var cryptoDetailWindow = new CryptoDetailWindow();
            var cryptoDetailViewModel = new CryptoDetailInfoViewModel(_currencyService);

            cryptoDetailViewModel.InputText = criptoSymbol;
            cryptoDetailWindow.DataContext = cryptoDetailViewModel;
            cryptoDetailWindow.Show();
        }

        public ICommand OnSearchCommand => new RelayCommand(OnSearch);

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
