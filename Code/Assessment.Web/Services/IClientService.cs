using System.Collections.Generic;

namespace Assessment.Web.Services
{
    public interface IClientService
    {
        int Create(Client client);
        IEnumerable<Client> Read();
    }
}