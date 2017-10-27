using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Assessment.Dto;
using Assessment.Gui.Annotations;
using Assessment.Gui.Commands;
using Assessment.Gui.Services;

namespace Assessment.Gui.ViewModels
{
    // NB Replace list with something.
    public class ClientListViewModel: INotifyPropertyChanged
    {
        public List<ClientViewModel> RowItems { get; set; } = new List<ClientViewModel>();

        public EditCommand EditCommand { get; set; }

        public ClientViewModel TemplateModel { get; set; }

        public void Read()
        {
            var clients = ClientService.Read();
            foreach (var client in clients)
            {
                var model = ClientViewModel.FromDataModel(client);
                RowItems.Add(model);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
