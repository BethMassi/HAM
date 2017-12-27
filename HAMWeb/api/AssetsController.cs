using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HAM.Models;
using HAMDataLibrary;

namespace HAMWeb.api
{
    [Produces("application/json")]
    [Route("api/Assets")]
    public class AssetsController : Controller
    {
        private readonly HAMDataContext _context;

        public AssetsController(HAMDataContext context)
        {
            _context = context;
        }

        // GET: api/Assets
        [HttpGet]
        public IEnumerable<Asset> GetAssets()
        {
            return _context.Assets;
        }

        // GET: api/Assets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssets([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assets = await _context.Assets.SingleOrDefaultAsync(m => m.Id == id);

            if (assets == null)
            {
                return NotFound();
            }

            return Ok(assets);
        }

        // PUT: api/Assets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssets([FromRoute] int id, [FromBody] Asset assets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assets.Id)
            {
                return BadRequest();
            }

            _context.Entry(assets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Assets
        [HttpPost]
        public async Task<IActionResult> PostAssets([FromBody] Asset assets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Assets.Add(assets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssets", new { id = assets.Id }, assets);
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssets([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assets = await _context.Assets.SingleOrDefaultAsync(m => m.Id == id);
            if (assets == null)
            {
                return NotFound();
            }

            _context.Assets.Remove(assets);
            await _context.SaveChangesAsync();

            return Ok(assets);
        }

        private bool AssetsExists(int id)
        {
            return _context.Assets.Any(e => e.Id == id);
        }
    }
}