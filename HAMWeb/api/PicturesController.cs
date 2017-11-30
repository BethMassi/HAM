using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HAMDataLibrary;

namespace HAMWeb.api
{
    [Produces("application/json")]
    [Route("api/Pictures")]
    public class PicturesController : Controller
    {
        private readonly HAMDataContext _context;

        public PicturesController(HAMDataContext context)
        {
            _context = context;
        }

        // GET: api/Pictures
        [HttpGet]
        public IEnumerable<Pictures> GetPictures()
        {
            return _context.Pictures;
        }

        // GET: api/Pictures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPictures([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pictures = await _context.Pictures.SingleOrDefaultAsync(m => m.Id == id);

            if (pictures == null)
            {
                return NotFound();
            }

            return Ok(pictures);
        }

        // PUT: api/Pictures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPictures([FromRoute] int id, [FromBody] Pictures pictures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pictures.Id)
            {
                return BadRequest();
            }

            _context.Entry(pictures).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PicturesExists(id))
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

        // POST: api/Pictures
        [HttpPost]
        public async Task<IActionResult> PostPictures([FromBody] Pictures pictures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pictures.Add(pictures);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPictures", new { id = pictures.Id }, pictures);
        }

        // DELETE: api/Pictures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePictures([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pictures = await _context.Pictures.SingleOrDefaultAsync(m => m.Id == id);
            if (pictures == null)
            {
                return NotFound();
            }

            _context.Pictures.Remove(pictures);
            await _context.SaveChangesAsync();

            return Ok(pictures);
        }

        private bool PicturesExists(int id)
        {
            return _context.Pictures.Any(e => e.Id == id);
        }
    }
}