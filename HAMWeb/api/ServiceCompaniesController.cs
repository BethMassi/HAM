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
    [Route("api/ServiceCompanies")]
    public class ServiceCompaniesController : Controller
    {
        private readonly HAMDataContext _context;

        public ServiceCompaniesController(HAMDataContext context)
        {
            _context = context;
        }

        // GET: api/ServiceCompanies
        [HttpGet]
        public IEnumerable<ServiceCompanies> GetServiceCompanies()
        {
            return _context.ServiceCompanies;
        }

        // GET: api/ServiceCompanies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceCompanies([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceCompanies = await _context.ServiceCompanies.SingleOrDefaultAsync(m => m.Id == id);

            if (serviceCompanies == null)
            {
                return NotFound();
            }

            return Ok(serviceCompanies);
        }

        // PUT: api/ServiceCompanies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceCompanies([FromRoute] int id, [FromBody] ServiceCompanies serviceCompanies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceCompanies.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceCompanies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceCompaniesExists(id))
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

        // POST: api/ServiceCompanies
        [HttpPost]
        public async Task<IActionResult> PostServiceCompanies([FromBody] ServiceCompanies serviceCompanies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ServiceCompanies.Add(serviceCompanies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceCompanies", new { id = serviceCompanies.Id }, serviceCompanies);
        }

        // DELETE: api/ServiceCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceCompanies([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceCompanies = await _context.ServiceCompanies.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceCompanies == null)
            {
                return NotFound();
            }

            _context.ServiceCompanies.Remove(serviceCompanies);
            await _context.SaveChangesAsync();

            return Ok(serviceCompanies);
        }

        private bool ServiceCompaniesExists(int id)
        {
            return _context.ServiceCompanies.Any(e => e.Id == id);
        }
    }
}