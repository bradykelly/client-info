using Assessment.Web.ViewModels.Base;

namespace Assessment.Web.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        ////public MainViewModel(IConfiguration configuration)
        ////{
        ////    _config = configuration;
        ////    _clients = new DataService();
        ////}

        ////private IConfiguration _config;
        ////private DataService _clients;

        ////public List<ClientViewModel> Items { get; set; } = new List<ClientViewModel>();

        ////public void Read()
        ////{
        ////    var items = _clients.BuildDummyData().ToList();
        ////    var models = items.Select(m => ClientViewModel.FromDto((Client)m));

        ////    Items = models.ToList();
        ////}
    }
}

