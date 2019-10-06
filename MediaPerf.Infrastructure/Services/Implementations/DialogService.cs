﻿using MediaPerf.Infrastructure.Services.Contracts;
using System.Windows;

namespace MediaPerf.Infrastructure.Services.Implementations
{
    public class DialogService : IDialogService
    {
        public bool? ShowMessage(string message)
        {
            //here you could display a window or just a simple MessageBox or whatever dialog you want...
            return MessageBox.Show(message, "Info",
                MessageBoxButton.OK,
                MessageBoxImage.Information)
                == MessageBoxResult.OK;
        }

        public bool? ShowConfirmationMessage(string message)
        {
            //here you could display a window or just a simple MessageBox or whatever dialog you want...
            return MessageBox.Show(message, "Confimation",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Exclamation)
                == MessageBoxResult.OK;
        }

        public bool? ShowMessage(string message, string title, MessageBoxButton button,
            MessageBoxImage image, MessageBoxResult result)
        {
            // here you could display a window or just a simple MessageBox or whatever dialog you want...
            return MessageBox.Show(message, title, button, image) == result;
        }

        public bool? ShowMessageNO(string message, string title, MessageBoxButton button,
            MessageBoxImage image, MessageBoxResult result)
        {
            // here you could display a window or just a simple MessageBox or whatever dialog you want...
            return MessageBox.Show(message, title, button, image) == result;
        }
    }
}
