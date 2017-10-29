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

        public ClientsController(IDataService dataService)
        {
            _clients = dataService;
        }

        [HttpPost]
        public int Post([Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] Client model)
        {
            return 0;
        }

        [HttpGet]
        [Route("Get")]
        [Produces(typeof(IEnumerable<Client>))]
        public async Task<IActionResult> Get()
        {
            // This is API side.
            var clients = await _clients.ReadAsync();
            return Ok(clients);
        }

        [HttpGet("{id}", Name = "Get")]
        [Produces(typeof(Client))]
        public async Task<IActionResult> Get(int id)
        {
            var clients = await _clients.ReadAsync(id);
            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
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
