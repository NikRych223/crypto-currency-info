using CommunityToolkit.Mvvm.Input;
using crypto_currency_info.Service;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace crypto_currency_info.ViewModels
{
    internal class ConverterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CurrencyService _currencyService;

        private string _inputCriptoOne;
        private string _inputCriptoTwo;
        private string _convertValue;

        public string InputCriptoOne
        {
            get { return _inputCriptoOne; }
            set
            {
                _inputCriptoOne = value;
                OnPropertyChanged(nameof(InputCriptoOne));
            }
        }
        public string InputCriptoTwo
        {
            get { return _inputCriptoTwo; }
            set
            {
                _inputCriptoTwo = value;
                OnPropertyChanged(nameof(InputCriptoTwo));
            }
        }
        public string ConvertValue
        {
            get { return _convertValue; }
            set
            {
                _convertValue = value;
                OnPropertyChanged(nameof(ConvertValue));
            }
        }

        public ConverterViewModel(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        private async void OnConvert()
        {
            if (InputCriptoOne != null && InputCriptoTwo != null)
            {
                var firstCripto = await _currencyService.GetOneCurrencieDetailBySymbol(InputCriptoOne);
                var secondCripto = await _currencyService.GetOneCurrencieDetailBySymbol(InputCriptoTwo);

                var convertResult = float.Parse(firstCripto.Volume) / float.Parse(secondCripto.Volume);
                var resultStringArray = convertResult.ToString().Split('.');

                ConvertValue = $"{resultStringArray[0]}.{resultStringArray[1].Substring(0, 4)}";
            }
        }

        public ICommand OnConvertCommand => new RelayCommand(OnConvert);

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
