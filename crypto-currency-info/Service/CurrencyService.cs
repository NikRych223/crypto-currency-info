using crypto_currency_info.Interfaces;
using crypto_currency_info.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace crypto_currency_info.Service
{
    class CurrencyService
    {
        private const string ApiBaseUrl = "https://api.coincap.io/v2/assets";

        public async Task<List<ICurrencyModel>> GetTopCurrencies(int limit)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{ApiBaseUrl}?limit={limit}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();

                    var parseData = JObject.Parse(jsonData)["data"];

                    var currencies = new List<ICurrencyModel>();

                    foreach (var item in parseData)
                    {
                        var cripto = new CurrencyModel
                        {
                            Id = item["id"].ToString(),
                            Rank = item["rank"].ToString(),
                            Symbol = item["symbol"].ToString(),
                            Name = item["name"].ToString(),
                            PriceUsd = item["priceUsd"].ToString()
                            
                        };

                        currencies.Add(cripto);
                    }

                    return currencies;
                }

                return null;
            }
        }
    }
}
