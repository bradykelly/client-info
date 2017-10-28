using System;
using System.Windows.Input;
using Assessment.Gui.ViewModels;
using Assessment.Web;

namespace Assessment.Gui.Commands
{
    public class EditCommand: ICommand
    {
        public EditCommand(Client client)
        {
            _client = client;
        }

        private Client _client;
        private bool _busy;

        public bool CanExecute(object parameter)
        {
            return !_busy;
        }

        public void Execute(object parameter)
        {
            try
            {
                var model = new ClientListViewModel();
                var type = 
                _busy = true;
            }
            finally
            {
                _busy = false;
            }

        }

        public event EventHandler CanExecuteChanged;
    }
}