using MediaPerf.Framework.App.Resources;
using MediaPerf.Infrastructure.Communs;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaPerf.Framework.App.MVVM.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ICommand CloseWindowCommand { get; private set; }
        public ICommand ValidateCommand { get; private set; }

        #region -- Contructor --
        public ShellViewModel(IRegionManager regionManager)
        {
            ApplicationTitle = ApplicationLabels.ApplicationTitle;

            Initialize();
            
        }
        #endregion

        // https://medium.com/@franklyndejesusmejia/close-a-window-from-viewmodel-using-wpf-and-mvvm-pattern-277ec7ef1805

        #region Methods

        private void Initialize()
        {
            CloseWindowCommand = new DelegateCommand<object>(OnCloseWindow, CanCloseWindow);
            ValidateCommand = new DelegateCommand(OnWindow, CanWindow);
        }

        private bool CanCloseWindow(object arg)
        {
            return true;
        }

        private void OnCloseWindow(object obj)
        {
            Console.WriteLine("Close Application...");
        }

        private bool CanWindow()
        {
            return true;
        }             

        private async void OnWindow()
        {
            Task<long> task = new Task<long>(Calculate);
            task.Start();

            BusyIndicatorManager.Instance.ShowBusy(1, "Please wait...");
            long total = await task;
            BusyIndicatorManager.Instance.CloseBusy(1);
        }             

        private long Calculate()
        {
            long lenght = 500000000;
            long result = 0;
            for (long i = 0; i < lenght; i++)
            {
                result += i;
            }
            return result;
        }
        #endregion
    }
}
