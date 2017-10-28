using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assessment.Web.Data;
using Assessment.Web.Models;
using Assessment.Web.Services;
using Assessment.Web.ViewModels;
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
                var model = ClientViewModel.FromDataModel(client);
                models.Add(model);
            }

            return View(models);
        }

        // GET: ClientViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientViewModel = await _context.Clients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (clientViewModel == null)
            {
                return NotFound();
            }

            return View();
        }

        // GET: ClientViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] ClientViewModel clientViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientViewModel);
        }

        // GET: ClientViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientViewModel = await _context.Clients.SingleOrDefaultAsync(m => m.Id == id);
            if (clientViewModel == null)
            {
                return NotFound();
            }
            return View(clientViewModel);
        }

        // POST: ClientViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GivenName,FamilyName,GenderId,DateOfBirth,Id")] ClientViewModel clientViewModel)
        {
            if (id != clientViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(clientViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clientViewModel);
        }

        // GET: ClientViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientViewModel = await _context.Clients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (clientViewModel == null)
            {
                return NotFound();
            }

            return View(clientViewModel);
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
