using crypto_currency_info.Interfaces;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace crypto_currency_info.Models
{
    class CurrencyModel : ICurrencyModel, INotifyPropertyChanged
    {
        private string _name;

        public string Id { get; set; }
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value) _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string PriceUsd { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            Trace.WriteLine("PropertyChanged!");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
