namespace crypto_currency_info.Interfaces
{
    interface ICurrencyModel
    {
        public string Id { get; set; }
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string PriceUsd { get; set; }
    }
}
