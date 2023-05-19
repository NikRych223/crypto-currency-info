using crypto_currency_info.Interfaces;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace crypto_currency_info.Models
{
    class CurrencyModel : ICurrencyModel, INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private string _rank;
        private string _symbol;
        private string _priceUsd;

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value) _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                if (_rank != value) _rank = value;
                OnPropertyChanged("Rank");
            }
        }

        public string Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                if (_symbol != value) _symbol = value;
                OnPropertyChanged("Symbol");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value) _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string PriceUsd
        {
            get
            {
                return _priceUsd;
            }
            set
            {
                if (_priceUsd  != value) _priceUsd = value;
                OnPropertyChanged("PriceUsd");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
