using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.ViewModel.Services
{
    public interface IDialogService
    {
        void ShowMessage(string message);
        void ShowErrorMessage(string errMessage);
        void ShowWarningMessage(string warnMessage);
        string OpenFile();
        string SaveFile();
    }
}
