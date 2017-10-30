using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Models;
using Assessment.Models.Dto;

namespace Assessment.Api.New.Services
{
    public interface IDataService
    {
        int CreateAsync(Client client);
        Task<IEnumerable<Client>> ReadAsync(ClientRequest request);
        Task UpdateAsync(Client client);
    }
}