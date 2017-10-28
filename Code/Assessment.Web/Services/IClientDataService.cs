using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.Web.Services
{
    public interface IClientDataClient
    {
        // NB catch up with implementation.
        Task CreateAsync(Client client);
        Task<IEnumerable<Client>> ReadAsync();
    }
}