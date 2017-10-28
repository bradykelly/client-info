using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Assessment.Dto;
using Assessment.Wpf.Services;
using Assessment.Wpf.ViewModels.Base;

namespace Assessment.Wpf.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ClientService _clients = new ClientService();

        public List<ClientViewModel> Items { get; set; } = new List<ClientViewModel>();

        public void Read()
        {
            var items = ClientService.BuildDummyData();
            var models = items.Select(ClientViewModel.FromDataModel).ToList();

            Items = models;
        }
    }
}

