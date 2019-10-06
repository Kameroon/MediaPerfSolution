using System.Windows;

namespace MediaPerf.Infrastructure.Services.Contracts
{
    public interface IDialogService
    {
        bool? ShowMessage(string message);
        bool? ShowMessage(string message, string title, MessageBoxButton yesNoCancel,
            MessageBoxImage question, MessageBoxResult oK);

        bool? ShowMessageNO(string message, string title, MessageBoxButton yesNoCancel,
            MessageBoxImage question, MessageBoxResult no);

        //string ShowMessage0(string message);
        //string ShowMessage1(string message, string title, MessageBoxButton yesNoCancel,
        //    MessageBoxImage question, MessageBoxResult oK);
    }
}