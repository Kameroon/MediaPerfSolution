
using System.Windows;

namespace MediaPerf.Framework.App.MVVM.Views
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();

            busyIndicator.DataContext = BusyIndicatorManager.Instance;
        }
    }
}
