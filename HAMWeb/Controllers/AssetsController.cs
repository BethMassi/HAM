using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HAMDataLibrary;

namespace HAMWeb.Controllers
{
    public class AssetsController : Controller
    {
        private readonly HAMDataContext _context;

        public AssetsController(HAMDataContext context)
        {
            _context = context;
        }

        // GET: Assets
        public async Task<IActionResult> Index()
        {
            var hAMDataContext = _context.Assets.Include(a => a.AssetServiceCompany1Navigation).Include(a => a.CategoryAssetNavigation).Include(a => a.LocationAssetNavigation);
            return View(await hAMDataContext.ToListAsync());
        }

        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assets = await _context.Assets
                .Include(a => a.AssetServiceCompany1Navigation)
                .Include(a => a.CategoryAssetNavigation)
                .Include(a => a.LocationAssetNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (assets == null)
            {
                return NotFound();
            }

            return View(assets);
        }

        // GET: Assets/Create
        public IActionResult Create()
        {
            ViewData["AssetServiceCompany1"] = new SelectList(_context.ServiceCompanies, "Id", "Name");
            ViewData["CategoryAsset"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["LocationAsset"] = new SelectList(_context.Locations, "Id", "Name");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Make,Model,SerialNumber,Url,PurchaseDate,PurchasePrice,Quantity,DrawingsAvailable,Notes,CreatedBy,Created,ModifiedBy,Modified,RowVersion,CategoryAsset,LocationAsset,AssetServiceCompany1")] Assets assets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetServiceCompany1"] = new SelectList(_context.ServiceCompanies, "Id", "Name", assets.AssetServiceCompany1);
            ViewData["CategoryAsset"] = new SelectList(_context.Categories, "Id", "Name", assets.CategoryAsset);
            ViewData["LocationAsset"] = new SelectList(_context.Locations, "Id", "Name", assets.LocationAsset);
            return View(assets);
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assets = await _context.Assets.SingleOrDefaultAsync(m => m.Id == id);
            if (assets == null)
            {
                return NotFound();
            }
            ViewData["AssetServiceCompany1"] = new SelectList(_context.ServiceCompanies, "Id", "Name", assets.AssetServiceCompany1);
            ViewData["CategoryAsset"] = new SelectList(_context.Categories, "Id", "Name", assets.CategoryAsset);
            ViewData["LocationAsset"] = new SelectList(_context.Locations, "Id", "Name", assets.LocationAsset);
            return View(assets);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Make,Model,SerialNumber,Url,PurchaseDate,PurchasePrice,Quantity,DrawingsAvailable,Notes,CreatedBy,Created,ModifiedBy,Modified,RowVersion,CategoryAsset,LocationAsset,AssetServiceCompany1")] Assets assets)
        {
            if (id != assets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetsExists(assets.Id))
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
            ViewData["AssetServiceCompany1"] = new SelectList(_context.ServiceCompanies, "Id", "Name", assets.AssetServiceCompany1);
            ViewData["CategoryAsset"] = new SelectList(_context.Categories, "Id", "Name", assets.CategoryAsset);
            ViewData["LocationAsset"] = new SelectList(_context.Locations, "Id", "Name", assets.LocationAsset);
            return View(assets);
        }

        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assets = await _context.Assets
                .Include(a => a.AssetServiceCompany1Navigation)
                .Include(a => a.CategoryAssetNavigation)
                .Include(a => a.LocationAssetNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (assets == null)
            {
                return NotFound();
            }

            return View(assets);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assets = await _context.Assets.SingleOrDefaultAsync(m => m.Id == id);
            _context.Assets.Remove(assets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetsExists(int id)
        {
            return _context.Assets.Any(e => e.Id == id);
        }
    }
}
