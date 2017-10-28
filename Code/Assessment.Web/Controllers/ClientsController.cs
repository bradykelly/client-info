using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assessment.Web.Data;
using Assessment.Web.Models;
using Assessment.Web.Services;
using Assessment.Web.ViewModels;
using Assessment.Web.ViewModels.Base;
using Microsoft.Extensions.Configuration;

namespace Assessment.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly IClientCrudService _clients;

        public ClientsController(AppDbContext context, IClientCrudService clientService, IConfiguration config)
        {
            _context = context;
            _config = config;
            _clients = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ret = new List<ClientViewModel>();
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
            var client = await _context.Clients.SingleOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            var model = ClientViewModel.FromDto(client);

            return View(model);
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
                try
                {
                    var client = model.ToDto(model);
                    client.Gender = null;
                    _context.Clients.Add(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(model.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var client = await _context.Clients.SingleOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            var model = ClientViewModel.FromDto(client);

            return View(model);
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
                try
                {
                    var client = model.ToDto(model);
                    client.Gender = null;
                    _context.Update(client);                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(model.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
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

        // GET: ClientViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.SingleOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            var model = ClientViewModel.FromDto(client);

            return View(model);
        }

        // POST: ClientViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientViewModel = await _context.Clients.SingleOrDefaultAsync(m => m.Id == id);
            _context.Clients.Remove(clientViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
