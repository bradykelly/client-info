using Assessment.Web.ViewModels.Base;

namespace Assessment.Web
{
    public class ClientRequest: BaseViewModel
    {
        public bool IsForReadAll { get; set; }
        public bool ClientId { get; set; }
        public Dto.Client Client { get; set; }
    }
}