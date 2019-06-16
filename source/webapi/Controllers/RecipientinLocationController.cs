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
    public class RecipientinLocationController : ControllerBase
    {
        private readonly lofyContext _context;

        public RecipientinLocationController(lofyContext context)
        {
            _context = context;
        }

        // GET: api/RecipientinLocation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipientinLocation>>> GetRecipientinLocation()
        {
            return await _context.RecipientinLocation.ToListAsync();
        }

        // GET: api/RecipientinLocation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipientinLocation>> GetRecipientinLocation(int id)
        {
            var recipientinLocation = await _context.RecipientinLocation.FindAsync(id);

            if (recipientinLocation == null)
            {
                return NotFound();
            }

            return recipientinLocation;
        }

        // PUT: api/RecipientinLocation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipientinLocation(int id, RecipientinLocation recipientinLocation)
        {
            if (id != recipientinLocation.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(recipientinLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipientinLocationExists(id))
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

        // POST: api/RecipientinLocation
        [HttpPost]
        public async Task<ActionResult<RecipientinLocation>> PostRecipientinLocation(RecipientinLocation recipientinLocation)
        {
            _context.RecipientinLocation.Add(recipientinLocation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecipientinLocationExists(recipientinLocation.LocationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecipientinLocation", new { id = recipientinLocation.LocationId }, recipientinLocation);
        }

        // DELETE: api/RecipientinLocation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecipientinLocation>> DeleteRecipientinLocation(int id)
        {
            var recipientinLocation = await _context.RecipientinLocation.FindAsync(id);
            if (recipientinLocation == null)
            {
                return NotFound();
            }

            _context.RecipientinLocation.Remove(recipientinLocation);
            await _context.SaveChangesAsync();

            return recipientinLocation;
        }

        private bool RecipientinLocationExists(int id)
        {
            return _context.RecipientinLocation.Any(e => e.LocationId == id);
        }
    }
}
