using Assessment.Dto;
using Assessment.Models.Dto;

namespace Assessment.Models
{
    public class ClientRequest
    {
        public bool IsForReadAll { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}