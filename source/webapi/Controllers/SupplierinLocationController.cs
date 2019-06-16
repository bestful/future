using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierinLocationController : ControllerBase
    {
        private readonly lofyContext _context;

        public SupplierinLocationController(lofyContext context)
        {
            _context = context;
        }

        // GET: api/SupplierinLocation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierinLocation>>> GetSupplierinLocation()
        {
            return await _context.SupplierinLocation.ToListAsync();
        }

        // GET: api/SupplierinLocation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierinLocation>> GetSupplierinLocation(int id)
        {
            var supplierinLocation = await _context.SupplierinLocation.FindAsync(id);

            if (supplierinLocation == null)
            {
                return NotFound();
            }

            return supplierinLocation;
        }

        // PUT: api/SupplierinLocation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplierinLocation(int id, SupplierinLocation supplierinLocation)
        {
            if (id != supplierinLocation.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(supplierinLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierinLocationExists(id))
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

        // POST: api/SupplierinLocation
        [HttpPost]
        public async Task<ActionResult<SupplierinLocation>> PostSupplierinLocation(SupplierinLocation supplierinLocation)
        {
            _context.SupplierinLocation.Add(supplierinLocation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SupplierinLocationExists(supplierinLocation.LocationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSupplierinLocation", new { id = supplierinLocation.LocationId }, supplierinLocation);
        }

        // DELETE: api/SupplierinLocation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SupplierinLocation>> DeleteSupplierinLocation(int id)
        {
            var supplierinLocation = await _context.SupplierinLocation.FindAsync(id);
            if (supplierinLocation == null)
            {
                return NotFound();
            }

            _context.SupplierinLocation.Remove(supplierinLocation);
            await _context.SaveChangesAsync();

            return supplierinLocation;
        }

        private bool SupplierinLocationExists(int id)
        {
            return _context.SupplierinLocation.Any(e => e.LocationId == id);
        }
    }
}
