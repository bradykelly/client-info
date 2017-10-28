using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Web.Services;
using Assessment.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assessment.Web.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        // NB Remove all EF.
        public ClientController(IClientService clientService)
        {
            _clients = clientService;
        }

        private IClientService _clients;

        [HttpGet]
        public List<string> Get()
        {
            var clients = _clients.Read().ToList();
            var models = new List<ClientViewModel>();
            foreach (var client in clients)
            {
                var model = new ClientViewModel();
                models.Add(ClientViewModel.FromDataModel(client));
            }

            return View(models);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
