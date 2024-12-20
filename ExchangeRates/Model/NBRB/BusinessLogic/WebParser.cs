using ExchangeRates.Model.NBRB.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Model.NBRB.BusinessLogic
{
    public class WebParser : IWebParser
    {
        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            Uri currenciesUri = new Uri(Constants.NBRB_ALL_CURRENCIES_REFERENCE);
            //Использую WebClient, т.к. он проще, чем HttpClient, а мне нужно сделать один запрос
            WebClient client = new WebClient();
            var response = await client.DownloadStringTaskAsync(currenciesUri);
            var currencies = JsonConvert.DeserializeObject<IEnumerable<Currency>>(response);

            return currencies;
        }

        public async Task<IEnumerable<Rate>> GetRates()
        {
            Uri referenceUri = new Uri(Constants.NBRB_TODAY_RATES_REFERENCE);

            WebClient client = new WebClient();
            var response = await client.DownloadStringTaskAsync(referenceUri);
            var rates = JsonConvert.DeserializeObject<IEnumerable<Rate>>(response);
            //var currenciesRates = JsonConvert.DeserializeObject<IEnumerable<Rate>>(jsonString).ToList().FindAll(x => )

            return rates;
        }

        public async Task GetOneRateDynamic(int currencyCode, DateTime startDate, DateTime endDate)
        {
            string baseRateDynamicUri = $"https://api.nbrb.by/ExRates/Rates/Dynamics/";
            StringBuilder uriBuilder = new StringBuilder(baseRateDynamicUri);

            string startDateFormat = startDate.ToString("yyyy/MM/dd");
            string endDateFormat = endDate.ToString("yyyy/MM/dd");

            uriBuilder.Append($"{currencyCode}?startDate={startDateFormat}&endDate={endDateFormat}");

            WebClient client = new WebClient();
            var response = await client.DownloadStringTaskAsync(uriBuilder.ToString());

            var rateDynamics = JsonConvert.DeserializeObject<IEnumerable<RateShort>>(response);

            Console.WriteLine(rateDynamics);
        }
    }
}
