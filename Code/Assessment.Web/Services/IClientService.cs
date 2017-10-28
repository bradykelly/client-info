using System.Collections.Generic;
using Assessment.Dto;

namespace Assessment.Web.Services
{
    public interface IClientService
    {
        int Create(Client client);
        IEnumerable<Client> Read();
    }
}