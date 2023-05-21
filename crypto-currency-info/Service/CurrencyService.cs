using crypto_currency_info.Exceptions;
using crypto_currency_info.Interfaces;
using crypto_currency_info.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace crypto_currency_info.Service
{
    class CurrencyService
    {
        private const string ApiBaseUrl = "https://api.coincap.io/v2/assets";

        public async Task<List<ICurrencyModel>> GetCurrenciesByLimit(int limit)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{ApiBaseUrl}?limit={limit}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await ResponseToCurrencyList(response);
                }

                throw new CurrencieNotFoundException("Currencie not found");
            }
        }

        public async Task<List<ICurrencyModel>> GetCurrencieBySymbol(string symbol)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{ApiBaseUrl}?search={symbol}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await ResponseToCurrencyList(response);
                }

                throw new CurrencieNotFoundException($"Currencie: {symbol}, not found");
            }
        }

        public async Task<List<ICurrencyModel>> GetCurrencieBySymbol(string symbol, int limit)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{ApiBaseUrl}?search={symbol}&limit={limit}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await ResponseToCurrencyList(response);
                }

                throw new CurrencieNotFoundException($"Currencie: {symbol}, not found");
            }
        }

        public async Task<ICurrencyDetailModel> GetOneCurrencieDetailBySymbol(string symbol, int? limitMarkets = 1)
        {
            var currencieList = await GetCurrencieBySymbol(symbol, 1);
            var currencie = currencieList[0];

            using (HttpClient client = new HttpClient())
            {
                string url = $"{ApiBaseUrl}/{currencie.Id}/markets?limit={limitMarkets}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    var parseData = JObject.Parse(jsonData)["data"];

                    var marketList = new List<MarketModel>();

                    foreach (var item in parseData)
                    {
                        var priceUsdArray = item["priceUsd"].ToString().Split('.');

                        var market = new MarketModel
                        {
                            MarketName = item["exchangeId"].ToString(),
                            MarketPriceUsd = $"{priceUsdArray[0]}.{priceUsdArray[1].Substring(0, 4)}"
                        };

                        marketList.Add(market);
                    }

                    var currencieVolumeChange = currencie.VolumeChange[0] == '-' ?
                        $"DOWN in {currencie.VolumeChange}" : $"UP in {currencie.VolumeChange}";

                    var currencyDetail = new CurrencyDetailModel
                    {
                        Id = currencie.Id,
                        Rank = currencie.Rank,
                        Symbol = currencie.Symbol,
                        Name = currencie.Name,
                        Volume = currencie.Volume,
                        VolumeChange = currencieVolumeChange,
                        PriceUsd = currencie.PriceUsd,
                        CoinUrl = currencie.CoinUrl,
                        Markets = marketList
                    };

                    return currencyDetail;
                }

                throw new CurrencieNotFoundException($"Currencie: {symbol}, not found");
            }
        }

        private async Task<List<ICurrencyModel>> ResponseToCurrencyList(HttpResponseMessage response)
        {
            string jsonData = await response.Content.ReadAsStringAsync();

            var parseData = JObject.Parse(jsonData)["data"];

            var currencies = new List<ICurrencyModel>();

            foreach (var item in parseData)
            {
                var priceUsdArray = item["priceUsd"].ToString().Split('.');

                var cripto = new CurrencyModel
                {
                    Id = item["id"].ToString(),
                    Rank = item["rank"].ToString(),
                    Symbol = item["symbol"].ToString(),
                    Name = item["name"].ToString(),
                    Volume = item["vwap24Hr"].ToString(),
                    VolumeChange = item["changePercent24Hr"].ToString(),
                    PriceUsd = float.Parse($"{priceUsdArray[0]}.{priceUsdArray[1].Substring(0, 4)}"),
                    CoinUrl = item["explorer"].ToString()
                };

                currencies.Add(cripto);
            }

            return currencies;
        }
    }
}
