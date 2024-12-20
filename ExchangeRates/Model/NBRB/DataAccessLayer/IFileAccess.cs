using System.Threading.Tasks;

namespace ExchangeRates.Model.NBRB.DataAccessLayer
{
    public interface IFileAccess
    {
        Task SetData(string data);
        void GetData();
    }
}
