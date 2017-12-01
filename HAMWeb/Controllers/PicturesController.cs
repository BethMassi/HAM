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
    public class PicturesController : Controller
    {
        private readonly HAMDataContext _context;

        public PicturesController(HAMDataContext context)
        {
            _context = context;
        }

        // GET: Pictures
        public async Task<IActionResult> Index()
        {
            var hAMDataContext = _context.Pictures.Include(p => p.PictureAssetNavigation).Include(p => p.PictureMaintanceLogNavigation);
            return View(await hAMDataContext.ToListAsync());
        }

        // GET: Pictures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictures = await _context.Pictures
                .Include(p => p.PictureAssetNavigation)
                .Include(p => p.PictureMaintanceLogNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pictures == null)
            {
                return NotFound();
            }

            return View(pictures);
        }

        // GET: Pictures/Create
        public IActionResult Create()
        {
            ViewData["PictureAsset"] = new SelectList(_context.Assets, "Id", "Name");
            ViewData["PictureMaintanceLog"] = new SelectList(_context.MaintenanceLogs, "Id", "Id");
            return View();
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Image,Caption,IsDefaultPicture,CreatedBy,Created,ModifiedBy,Modified,RowVersion,PictureAsset,PictureMaintanceLog")] Pictures pictures)
        public async Task<IActionResult> Create([Bind("Id,Image,Caption,IsDefaultPicture,PictureAsset,PictureMaintanceLog")] Picture pictures)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pictures);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PictureAsset"] = new SelectList(_context.Assets, "Id", "Name", pictures.PictureAsset);
            ViewData["PictureMaintanceLog"] = new SelectList(_context.MaintenanceLogs, "Id", "Id", pictures.PictureMaintanceLog);
            return View(pictures);
        }

        // GET: Pictures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictures = await _context.Pictures.SingleOrDefaultAsync(m => m.Id == id);
            if (pictures == null)
            {
                return NotFound();
            }
            ViewData["PictureAsset"] = new SelectList(_context.Assets, "Id", "Name", pictures.PictureAsset);
            ViewData["PictureMaintanceLog"] = new SelectList(_context.MaintenanceLogs, "Id", "Id", pictures.PictureMaintanceLog);
            return View(pictures);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Caption,IsDefaultPicture,CreatedBy,Created,ModifiedBy,Modified,RowVersion,PictureAsset,PictureMaintanceLog")] Pictures pictures)
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Caption,IsDefaultPicture,PictureAsset,PictureMaintanceLog")] Picture pictures)
        {
            if (id != pictures.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pictures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PicturesExists(pictures.Id))
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
            ViewData["PictureAsset"] = new SelectList(_context.Assets, "Id", "Name", pictures.PictureAsset);
            ViewData["PictureMaintanceLog"] = new SelectList(_context.MaintenanceLogs, "Id", "Id", pictures.PictureMaintanceLog);
            return View(pictures);
        }

        // GET: Pictures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictures = await _context.Pictures
                .Include(p => p.PictureAssetNavigation)
                .Include(p => p.PictureMaintanceLogNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pictures == null)
            {
                return NotFound();
            }

            return View(pictures);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pictures = await _context.Pictures.SingleOrDefaultAsync(m => m.Id == id);
            _context.Pictures.Remove(pictures);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PicturesExists(int id)
        {
            return _context.Pictures.Any(e => e.Id == id);
        }
    }
}
