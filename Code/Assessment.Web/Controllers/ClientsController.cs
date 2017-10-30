using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;
using Assessment.Models.Dto;
using Assessment.Web.Services;
using Assessment.Web.ViewModels;
using Assessment.Web.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Assessment.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IDataClient _clients;

        public ClientsController(IDataClient clientService, IConfiguration config)
        {
            _clients = clientService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var client = new Client();
            var model = ClientViewModel.FromDto(client);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] ClientViewModel model)
        {
            ValidateClient(model);

            if (ModelState.IsValid)
            {
                var client = model.ToDto(model);
                client.Gender = null;
                await _clients.Create(client);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var models = new List<ClientViewModel>();

            var rawClients = await _clients.ReadAsync();
            foreach (var client in rawClients)
            {
                var model = ClientViewModel.FromDto(client);
                models.Add(model);
            }

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var request = new ClientRequest();
            request.ClientId = id;
            var client = await _clients.ReadAsync(request);
            if (client == null)
            {
                return NotFound();
            }
            var model = ClientViewModel.FromDto(client.Single());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Zero is an invalid Client Id.", nameof(id));
            }

            var request = new ClientRequest {ClientId = id};
            var client = await _clients.ReadAsync(request);
            if (client == null)
            {
                return NotFound();
            }

            var model = ClientViewModel.FromDto(client);

            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] ClientViewModel model)
        {
            // Can't rely on client side validations only.
            ValidateClient(model);

            // Now we're working with a ModelState with extra errors from the above validation.
            if (ModelState.IsValid)
            {
                var client = model.ToDto(model);
                client.Gender = null;
                await _clients.UpdateAsync(client);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        private void ValidateClient(ClientViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.GivenName))
            {
                ModelState.AddModelError(nameof(model.GivenName), $"{nameof(model.GivenName)} is required.");
            }
            if (string.IsNullOrWhiteSpace(model.FamilyName))
            {
                ModelState.AddModelError(nameof(model.FamilyName), $"{nameof(model.FamilyName)} is required.");
            }
            if (!model.GenderId.HasValue)
            {
                ModelState.AddModelError(nameof(model.GenderId), $"{nameof(model.GenderId)} is required.");
            }
            if (string.IsNullOrWhiteSpace(model.DateOfBirth))
            {
                ModelState.AddModelError(nameof(model.DateOfBirth), $"{nameof(model.DateOfBirth)} is required.");
            }
            if (!DateTime.TryParseExact(model.DateOfBirth, BaseViewModel.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var check))
            {
                ModelState.AddModelError(nameof(model.DateOfBirth), $"Must be of the format {BaseViewModel.DateFormat}");
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = new Client();////await _context.Clients.SingleOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            var model = ClientViewModel.FromDto(client);

            return View(model);
        }

        ////[HttpPost, ActionName("Delete")]
        ////[ValidateAntiForgeryToken]
        ////public async Task<IActionResult> DeleteConfirmed(int id)
        ////{
        ////    var clientViewModel = await _context.Clients.SingleOrDefaultAsync(m => m.Id == id);
        ////    _context.Clients.Remove(clientViewModel);
        ////    await _context.SaveChangesAsync();
        ////    return RedirectToAction(nameof(Index));
        ////}

        ////private bool ClientExists(int id)
        ////{
        ////    return _context.Clients.Any(e => e.Id == id);
        ////}
    }
}
