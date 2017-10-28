using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Api.Services;
using Assessment.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assessment.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Clients")]
    public class ClientsController : Controller
    {
        private readonly IDataService _clients;

        public ClientsController(IDataService clientService)
        {
            _clients = clientService;
        }

    [HttpGet]
    [Route("Get")]
    public async Task<IEnumerable<Client>> Get()
    {
        // API side.
        IEnumerable<Client> clients = await _clients.ReadAsync();
        return clients;
    }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
