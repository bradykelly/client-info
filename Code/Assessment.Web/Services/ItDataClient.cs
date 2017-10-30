using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Dto;
using Assessment.Models;
using Assessment.Models.Dto;

namespace Assessment.Web.Services
{
    public interface IDataClient
    {
        // NB catch up with implementation.
        Task Create(Client client);
        Task<IEnumerable<Client>> ReadAsync();
        Task<IEnumerable<Client>> ReadAsync(ClientRequest request);
        Task UpdateAsync(Client client);
    }
}