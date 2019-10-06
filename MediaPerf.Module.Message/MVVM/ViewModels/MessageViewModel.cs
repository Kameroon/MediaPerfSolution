using MediaPerf.Infrastructure.Communs;
using MediaPerf.Infrastructure.Events;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaPerf.Module.Message.MVVM.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        public ICommand SentMessageCommand { get; private set; }


        private ObservableCollection<string> _message = new ObservableCollection<string>();

        public ObservableCollection<string> Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        public MessageViewModel(IEventAggregator eventAggregator)
        {

            //SentMessageCommand = new DelegateCommand(OnBrowse, CanBrowse);

            // -- Send message by event --
            eventAggregator.GetEvent<SendMessageEvent>().Subscribe(ReceveMessage);
        }

        private bool CanBrowse()
        {
            return true;
        }

        private void OnBrowse()
        {
           
        }

        private void ReceveMessage(string parameter)
        {
            Message.Add(parameter);
        }
    }
}
