using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HAMWeb.Models;

namespace HAMWeb.Controllers
{
    public class MaintenanceLogsController : Controller
    {
        private readonly HAMDataContext _context;

        public MaintenanceLogsController(HAMDataContext context)
        {
            _context = context;
        }

        // GET: MaintenanceLogs
        public async Task<IActionResult> Index()
        {
            var hAMDataContext = _context.MaintenanceLogs.Include(m => m.MaintanceLogAssetNavigation);
            return View(await hAMDataContext.ToListAsync());
        }

        // GET: MaintenanceLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceLogs = await _context.MaintenanceLogs
                .Include(m => m.MaintanceLogAssetNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (maintenanceLogs == null)
            {
                return NotFound();
            }

            return View(maintenanceLogs);
        }

        // GET: MaintenanceLogs/Create
        public IActionResult Create()
        {
            ViewData["MaintanceLogAsset"] = new SelectList(_context.Assets, "Id", "Name");
            return View();
        }

        // POST: MaintenanceLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaintenanceDate,Notes,IsCompleted,CreatedBy,Created,ModifiedBy,Modified,RowVersion,MaintanceLogAsset")] MaintenanceLogs maintenanceLogs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintenanceLogs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaintanceLogAsset"] = new SelectList(_context.Assets, "Id", "Name", maintenanceLogs.MaintanceLogAsset);
            return View(maintenanceLogs);
        }

        // GET: MaintenanceLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceLogs = await _context.MaintenanceLogs.SingleOrDefaultAsync(m => m.Id == id);
            if (maintenanceLogs == null)
            {
                return NotFound();
            }
            ViewData["MaintanceLogAsset"] = new SelectList(_context.Assets, "Id", "Name", maintenanceLogs.MaintanceLogAsset);
            return View(maintenanceLogs);
        }

        // POST: MaintenanceLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaintenanceDate,Notes,IsCompleted,CreatedBy,Created,ModifiedBy,Modified,RowVersion,MaintanceLogAsset")] MaintenanceLogs maintenanceLogs)
        {
            if (id != maintenanceLogs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintenanceLogs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceLogsExists(maintenanceLogs.Id))
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
            ViewData["MaintanceLogAsset"] = new SelectList(_context.Assets, "Id", "Name", maintenanceLogs.MaintanceLogAsset);
            return View(maintenanceLogs);
        }

        // GET: MaintenanceLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceLogs = await _context.MaintenanceLogs
                .Include(m => m.MaintanceLogAssetNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (maintenanceLogs == null)
            {
                return NotFound();
            }

            return View(maintenanceLogs);
        }

        // POST: MaintenanceLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenanceLogs = await _context.MaintenanceLogs.SingleOrDefaultAsync(m => m.Id == id);
            _context.MaintenanceLogs.Remove(maintenanceLogs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceLogsExists(int id)
        {
            return _context.MaintenanceLogs.Any(e => e.Id == id);
        }
    }
}
