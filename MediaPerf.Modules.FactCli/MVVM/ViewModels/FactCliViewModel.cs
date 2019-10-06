using MediaPerf.Infrastructure.Communs;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaPerf.Modules.FactCli.MVVM.ViewModels
{
    public class FactCliViewModel : ViewModelBase
    {
        #region Fields

        #endregion

        #region Attributes
        public ICommand ValidateCommand { get; private set; }
        public ICommand BrowseCommand { get; private set; }
        #endregion

        #region Properties

        #endregion

        #region Constructor
        public FactCliViewModel()
        {
            Initialize();
        }
        #endregion

        #region Methods
        private void Initialize()
        {

            ValidateCommand = new DelegateCommand(OnWindow, CanWindow);
            BrowseCommand = new DelegateCommand(OnBrowse, CanBrowse);
        }

        private bool CanBrowse()
        {
            return true;
        }

        private void OnBrowse()
        {
            Console.WriteLine("Brower .......................");
        }

        private void OnWindow()
        {
            Console.WriteLine("Validate 1000000000000000000000000");
        }

        private bool CanWindow()
        {
            return true;
        }
        #endregion
    }
}
