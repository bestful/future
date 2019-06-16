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
    public class LinkinSystemController : ControllerBase
    {
        private readonly lofyContext _context;

        public LinkinSystemController(lofyContext context)
        {
            _context = context;
        }

        // GET: api/LinkinSystem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LinkinSystem>>> GetLinkinSystem()
        {
            return await _context.LinkinSystem.ToListAsync();
        }

        // GET: api/LinkinSystem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LinkinSystem>> GetLinkinSystem(string id)
        {
            var linkinSystem = await _context.LinkinSystem.FindAsync(id);

            if (linkinSystem == null)
            {
                return NotFound();
            }

            return linkinSystem;
        }

        // PUT: api/LinkinSystem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLinkinSystem(string id, LinkinSystem linkinSystem)
        {
            if (id != linkinSystem.System)
            {
                return BadRequest();
            }

            _context.Entry(linkinSystem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkinSystemExists(id))
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

        // POST: api/LinkinSystem
        [HttpPost]
        public async Task<ActionResult<LinkinSystem>> PostLinkinSystem(LinkinSystem linkinSystem)
        {
            _context.LinkinSystem.Add(linkinSystem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LinkinSystemExists(linkinSystem.System))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLinkinSystem", new { id = linkinSystem.System }, linkinSystem);
        }

        // DELETE: api/LinkinSystem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LinkinSystem>> DeleteLinkinSystem(string id)
        {
            var linkinSystem = await _context.LinkinSystem.FindAsync(id);
            if (linkinSystem == null)
            {
                return NotFound();
            }

            _context.LinkinSystem.Remove(linkinSystem);
            await _context.SaveChangesAsync();

            return linkinSystem;
        }

        private bool LinkinSystemExists(string id)
        {
            return _context.LinkinSystem.Any(e => e.System == id);
        }
    }
}
