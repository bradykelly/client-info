using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Assessment.Api.New.Services;
using System;

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
        [Produces(typeof(int))]
        public int Post([Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] Client client)
        {
            var ret = _clients.Create(client);
            return ret;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Client>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clients = await _clients.ReadAsync();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
        }

        [HttpGet("Get/{id:int}")]
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
