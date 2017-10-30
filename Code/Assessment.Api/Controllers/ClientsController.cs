using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Assessment.Api.New.Services;
using System.Linq;
using Assessment.Models;
using Assessment.Models.Dto;

namespace Assessment.Api.New.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ClientsController : Controller
    {
        private readonly IDataService _clients;

        public ClientsController(IDataService dataService)
        {
            _clients = dataService;
        }

        [HttpPost]
        [Produces(typeof(IEnumerable<Client>))]
        public async Task<IActionResult> Post([Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] ClientRequest client)
        {
            if (client.IsForReadAll)
            {
                var ret = _clients.CreateAsync(client.Client);
                return Ok(ret);
            }

            var req = new ClientRequest {ClientId = client.ClientId};
            var clients = await _clients.ReadAsync(req);
            return Ok(clients);
        }

        [HttpPost]
        public async Task<IActionResult> Get(string requestJson)
        {
            var reqIn = JsonConvert.DeserializeObject<ClientRequest>(requestJson);
            if (reqIn.IsForReadAll)
            {
                var allClients = await _clients.ReadAsync(reqIn);
                return Ok(allClients); 
            }
            var reqOut = new ClientRequest();
            reqOut.ClientId = reqIn.ClientId;
            var clients = await _clients.ReadAsync(reqOut);
            if (reqIn.IsForReadAll)
            {
                return Ok(clients);
            }

            // Prevent multiple iterations of Clients.
            var clientList = clients as IList<Client> ?? clients.ToList();
            if (clientList.Any())
            {
                return Ok(clientList.Single());
            }

            return BadRequest();
        }

        [HttpGet("Get/{id:int}")]
        [Produces(typeof(Client))]
        public async Task<IActionResult> Get(int id)
        {
            var request = new ClientRequest();
            request.ClientId = id;
            var client = await _clients.ReadAsync(request);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPut]
        public void Put([Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] string json)
        {
            // NB Edit isn't saving.
            var client = JsonConvert.DeserializeObject<Client>(json);
            _clients.UpdateAsync(client);
        }

        [HttpDelete("Delete/{id:int}")]
        public void Delete(int id)
        {
        }
    }
}
