using System.Windows;

namespace MediaPerf.Infrastructure.Communs.MessageBox.Contracts
{
    public interface IMessageBoxConsolidateHelper
    {
        void DisplayMessageBox(string errorMessage,
            string messageTitle, MessageBoxButton messageBoxButton,
            MessageBoxImage messageBoxImage, MessageBoxResult messageBoxResult);
    }
}