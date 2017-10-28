using System.Collections.Generic;
using System.Linq;
using Assessment.Web.Services;
using Assessment.Web.ViewModels.Base;

namespace Assessment.Web.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ClientService _clients = new ClientService();

        public List<ClientViewModel> Items { get; set; } = new List<ClientViewModel>();

        public void Read()
        {
            var items = ClientService.BuildDummyData().ToList();
            var models = items.Select(m => ClientViewModel.FromDataModel((Dto.Client)m));

            Items = models;
        }
    }
}

