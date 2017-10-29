using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.Web.Services
{
    public interface IDataClient
    {
        // NB catch up with implementation.
        Task CreateAsync(Client client);
        Task<IEnumerable<Client>> ReadAsync();
        Task<Client> ReadAsync(int id);
    }
}