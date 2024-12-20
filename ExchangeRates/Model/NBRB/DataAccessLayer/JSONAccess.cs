using ExchangeRates.ViewModel.Services;
using System.IO;
using System.Threading.Tasks;

namespace ExchangeRates.Model.NBRB.DataAccessLayer
{
    public class JSONAccess : IFileAccess
    {
        private readonly IDialogService dialogService;
        public JSONAccess(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        public void GetData()
        {
        }

        public async Task SetData(string data)
        {
            string filePath = dialogService.SaveFile();
            if (!string.IsNullOrEmpty(filePath))
            {
                using (var streamWriter = new StreamWriter(filePath))
                {
                    await streamWriter.WriteAsync(data);
                }
            }
        }
    }
}
