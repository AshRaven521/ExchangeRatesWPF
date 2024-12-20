using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ExchangeRates.Commands;
using ExchangeRates.Model.NBRB.BusinessLogic;
using ExchangeRates.Model.NBRB.Entities;
using ExchangeRates.ViewModel.Services;

namespace ExchangeRates.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private readonly IWebParser parser;
        private readonly IDialogService dialogService;

        public MainViewModel(IWebParser parser, IDialogService dialogService)
        {
            this.parser = parser;
            this.dialogService = dialogService;
        }

        private ObservableCollection<Rate> rates = new ObservableCollection<Rate>();

        public ObservableCollection<Rate> Rates
        {
            get
            {
                return rates;
            }
            set
            {
                if (rates == value)
                {
                    return;
                }
                rates = value;
                OnPropertyChanged(nameof(Rates));
            }
        }



        private Command testCommand;

        public Command TestCommand
        {
            get
            {
                if (testCommand is null)
                {
                    return testCommand = new Command(async () => await FillRates());
                }
                else
                {
                    return testCommand;
                }
            }
        }

        private async Task FillRates()
        {
            var downloadedRates = await parser.GetRates();
            Rates = new ObservableCollection<Rate>(downloadedRates);

            await parser.GetOneRateDynamic(downloadedRates.ToList().ElementAt(1).Cur_ID, DateTime.Parse("2021-07-01"), DateTime.Parse("2021-07-31"));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
