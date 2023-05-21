using crypto_currency_info.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace crypto_currency_info.Models
{
    class CurrencyModel : ICurrencyModel, INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private string _volume;
        private string _volumeChange;
        private string _rank;
        private string _symbol;
        private float _priceUsd;
        private string _coinUrl;

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value) _id = value;
                OnPropertyChanged(nameof(Id));
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
                OnPropertyChanged(nameof(Rank));
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
                OnPropertyChanged(nameof(Symbol));
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
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (_volume != value) _volume = value;
                OnPropertyChanged(nameof(Volume));
            }
        }

        public string VolumeChange
        {
            get
            {
                return _volumeChange;
            }
            set
            {
                if (_volumeChange != value) _volumeChange = value;
                OnPropertyChanged(nameof(VolumeChange));
            }
        }

        public float PriceUsd
        {
            get
            {
                return _priceUsd;
            }
            set
            {
                if (_priceUsd != value) _priceUsd = value;
                OnPropertyChanged(nameof(PriceUsd));
            }
        }

        public string CoinUrl
        {
            get
            {
                return _coinUrl;
            }
            set
            {
                if (_coinUrl != value) _coinUrl = value;
                OnPropertyChanged(nameof(CoinUrl));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
