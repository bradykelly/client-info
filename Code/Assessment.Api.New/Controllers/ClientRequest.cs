using Assessment.Web;

namespace Assessment.Api.New.Controllers
{
    public class ClientRequest
    {
        public bool IsForReadAll { get; set; }
        public Client Client { get; set; }
    }
}