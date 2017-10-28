using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Web;

namespace Assessment.Api.Services
{
    public interface IDataService
    {
        int Create(Client client);
        IEnumerable<Client> Read();
        Task<IEnumerable<Client>> ReadAsync();
    }
}