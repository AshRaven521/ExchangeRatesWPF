using ExchangeRates.Model.NBRB.BusinessLogic;
using ExchangeRates.Model.NBRB.DataAccessLayer;
using ExchangeRates.ViewModel;
using ExchangeRates.ViewModel.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ExchangeRates
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<IDialogService, DialogService>();
                    services.AddScoped<IFileAccess, JSONAccess>();
                    services.AddScoped<IWebParser, WebParser>();
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();
                }).Build();
            
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            var startFrom = AppHost.Services.GetRequiredService<MainWindow>();
            startFrom.DataContext = AppHost.Services.GetRequiredService<MainViewModel>();
            startFrom.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            

            base.OnExit(e);
        }
    }
}
