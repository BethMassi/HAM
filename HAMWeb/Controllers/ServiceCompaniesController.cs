using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HAMDataLibrary;
using HAM.Models;

namespace HAMWeb.Controllers
{
    public class ServiceCompaniesController : Controller
    {
        private readonly HAMDataContext _context;

        public ServiceCompaniesController(HAMDataContext context)
        {
            _context = context;
        }

        // GET: ServiceCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceCompanies.ToListAsync());
        }

        // GET: ServiceCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceCompanies = await _context.ServiceCompanies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (serviceCompanies == null)
            {
                return NotFound();
            }

            return View(serviceCompanies);
        }

        // GET: ServiceCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,ContactName,Phone,CreatedBy,Created,ModifiedBy,Modified,RowVersion")] ServiceCompanies serviceCompanies)
        public async Task<IActionResult> Create([Bind("Id,Name,ContactName,Phone")] ServiceCompany serviceCompanies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceCompanies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceCompanies);
        }

        // GET: ServiceCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceCompanies = await _context.ServiceCompanies.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceCompanies == null)
            {
                return NotFound();
            }
            return View(serviceCompanies);
        }

        // POST: ServiceCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ContactName,Phone,CreatedBy,Created,ModifiedBy,Modified,RowVersion")] ServiceCompanies serviceCompanies)
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ContactName,Phone")] ServiceCompany serviceCompanies)
        {
            if (id != serviceCompanies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceCompanies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceCompaniesExists(serviceCompanies.Id))
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
            return View(serviceCompanies);
        }

        // GET: ServiceCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceCompanies = await _context.ServiceCompanies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (serviceCompanies == null)
            {
                return NotFound();
            }

            return View(serviceCompanies);
        }

        // POST: ServiceCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceCompanies = await _context.ServiceCompanies.SingleOrDefaultAsync(m => m.Id == id);
            _context.ServiceCompanies.Remove(serviceCompanies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceCompaniesExists(int id)
        {
            return _context.ServiceCompanies.Any(e => e.Id == id);
        }
    }
}
