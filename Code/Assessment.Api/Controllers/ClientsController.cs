using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Api.Services;
using Assessment.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assessment.Api.Controllers
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

        [HttpPost("Create")]
        [Produces(typeof(int))]
        public int Create([Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] Client client)
        {
            var ret = _clients.Create(client);
            return ret;
        }

        [HttpGet("Read")]
        [Produces(typeof(IEnumerable<Client>))]
        public async Task<IActionResult> Read()
        {
            var clients = await _clients.ReadAsync();
            return Ok(clients);
        }

        [HttpGet("Read/{id}")]
        [Produces(typeof(Client))]
        public async Task<IActionResult> Read(int id)
        {
            var client = await _clients.ReadAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpGet("Update")]
        public void Put([Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] string json)
        {
            // NB Edit isn't saving.
            var client = JsonConvert.DeserializeObject<Client>(json);
            _clients.UpdateAsync(client);
        }

        [HttpGet("api/Client/Delete/{id:int}")]
        public void Delete(int id)
        {
        }
    }
}
