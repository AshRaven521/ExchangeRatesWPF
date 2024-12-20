using ExchangeRates.Model.NBRB.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRates.Model.NBRB.BusinessLogic
{
    public interface IWebParser
    {
        Task<IEnumerable<Currency>> GetCurrencies();
        Task GetOneRateDynamic(int currencyCode, System.DateTime startDate, System.DateTime endDate);
        Task<IEnumerable<Rate>> GetRates();
    }
}