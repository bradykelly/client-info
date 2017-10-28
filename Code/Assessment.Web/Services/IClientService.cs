using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.Web.Services
{
    public interface IClientCrudService
    {
        int Create(Client client);
        IEnumerable<Client> Read();
        Task<IEnumerable<Client>> ReadAsync();
    }
}