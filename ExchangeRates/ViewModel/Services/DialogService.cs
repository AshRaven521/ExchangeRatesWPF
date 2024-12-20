using Microsoft.Win32;
using System;
using System.Windows;

namespace ExchangeRates.ViewModel.Services
{
    public class DialogService : IDialogService
    {
        public string OpenFile()
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Json files (*.json)|*.json";
            openFileDialog.Title = "Выберите файл с курсами валют";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return string.Empty;
        }

        public string SaveFile()
        {
            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Json files (*.json)|*.json";
            saveFileDialog.Title = "Выберите файл для сохранения даных";

            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }
            return string.Empty;
        }

        public void ShowErrorMessage(string errMessage)
        {
            MessageBox.Show(errMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowWarningMessage(string warnMessage)
        {
            MessageBox.Show(warnMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
