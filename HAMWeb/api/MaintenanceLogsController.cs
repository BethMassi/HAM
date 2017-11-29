using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HAMWeb.Models;

namespace HAMWeb.api
{
    [Produces("application/json")]
    [Route("api/MaintenanceLogs")]
    public class MaintenanceLogsController : Controller
    {
        private readonly HAMDataContext _context;

        public MaintenanceLogsController(HAMDataContext context)
        {
            _context = context;
        }

        // GET: api/MaintenanceLogs
        [HttpGet]
        public IEnumerable<MaintenanceLogs> GetMaintenanceLogs()
        {
            return _context.MaintenanceLogs;
        }

        // GET: api/MaintenanceLogs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaintenanceLogs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maintenanceLogs = await _context.MaintenanceLogs.SingleOrDefaultAsync(m => m.Id == id);

            if (maintenanceLogs == null)
            {
                return NotFound();
            }

            return Ok(maintenanceLogs);
        }

        // PUT: api/MaintenanceLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintenanceLogs([FromRoute] int id, [FromBody] MaintenanceLogs maintenanceLogs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maintenanceLogs.Id)
            {
                return BadRequest();
            }

            _context.Entry(maintenanceLogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceLogsExists(id))
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

        // POST: api/MaintenanceLogs
        [HttpPost]
        public async Task<IActionResult> PostMaintenanceLogs([FromBody] MaintenanceLogs maintenanceLogs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MaintenanceLogs.Add(maintenanceLogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaintenanceLogs", new { id = maintenanceLogs.Id }, maintenanceLogs);
        }

        // DELETE: api/MaintenanceLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenanceLogs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maintenanceLogs = await _context.MaintenanceLogs.SingleOrDefaultAsync(m => m.Id == id);
            if (maintenanceLogs == null)
            {
                return NotFound();
            }

            _context.MaintenanceLogs.Remove(maintenanceLogs);
            await _context.SaveChangesAsync();

            return Ok(maintenanceLogs);
        }

        private bool MaintenanceLogsExists(int id)
        {
            return _context.MaintenanceLogs.Any(e => e.Id == id);
        }
    }
}