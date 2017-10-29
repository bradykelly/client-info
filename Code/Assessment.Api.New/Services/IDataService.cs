using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Web;

namespace Assessment.Api.New.Services
{
    public interface IDataService
    {
        int Create(Client client);
        Task<IEnumerable<Client>> ReadAsync();
        Task<Client> ReadAsync(int id);
        Task UpdateAsync(Client client);
    }
}