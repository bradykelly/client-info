using System.Collections.Generic;
using System.Linq;
using Assessment.Web.Services;
using Assessment.Web.ViewModels.Base;
using Microsoft.Extensions.Configuration;

namespace Assessment.Web.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IConfiguration configuration)
        {
            _config = configuration;
            _clients = new ClientCrudService(_config);
        }

        private IConfiguration _config;
        private ClientCrudService _clients;

        public List<ClientViewModel> Items { get; set; } = new List<ClientViewModel>();

        public void Read()
        {
            var items = _clients.BuildDummyData().ToList();
            var models = items.Select(m => ClientViewModel.FromDataModel((Client)m));

            Items = models.ToList();
        }
    }
}

