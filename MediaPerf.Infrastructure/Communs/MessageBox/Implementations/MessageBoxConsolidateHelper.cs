using MediaPerf.Infrastructure.Communs.MessageBox.Contracts;
using MediaPerf.Infrastructure.Services.Contracts;
using System.Windows;

namespace MediaPerf.Infrastructure.Communs.MessageBox.Implementations
{
    public class MessageBoxConsolidateHelper : IMessageBoxConsolidateHelper
    {
        private readonly IDialogService _dialogService;

        public MessageBoxConsolidateHelper(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public void DisplayMessageBox(string errorMessage,
            string messageTitle, MessageBoxButton messageBoxButton,
            MessageBoxImage messageBoxImage, MessageBoxResult messageBoxResult)
        {
            _dialogService.ShowMessage(errorMessage,
                                      messageTitle,
                                      messageBoxButton,
                                      messageBoxImage,
                                      messageBoxResult);
        }
    }
}