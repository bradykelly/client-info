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

        [HttpPost]
        public int Post([Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] Client model)
        {
            // NB Implement.
            return 0;
        }

        [HttpGet("Get")]
        [Produces(typeof(IEnumerable<Client>))]
        public async Task<IActionResult> Get()
        {
            var clients = await _clients.ReadAsync();
            return Ok(clients);
        }

        [HttpGet("api/Client/Get/{id:int}")]
        [Produces(typeof(Client))]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _clients.ReadAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpGet("api/Client/Put")]
        public void Put([Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] Client client)
        {

        }

        [HttpGet("api/Client/Delete/{id:int}")]
        public void Delete(int id)
        {
        }
    }
}
