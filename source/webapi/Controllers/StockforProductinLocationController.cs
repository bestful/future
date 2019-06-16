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
    public class StockforProductinLocationController : ControllerBase
    {
        private readonly lofyContext _context;

        public StockforProductinLocationController(lofyContext context)
        {
            _context = context;
        }

        // GET: api/StockforProductinLocation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockforProductinLocation>>> GetStockforProductinLocation()
        {
            return await _context.StockforProductinLocation.ToListAsync();
        }

        // GET: api/StockforProductinLocation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockforProductinLocation>> GetStockforProductinLocation(int id)
        {
            var stockforProductinLocation = await _context.StockforProductinLocation.FindAsync(id);

            if (stockforProductinLocation == null)
            {
                return NotFound();
            }

            return stockforProductinLocation;
        }

        // PUT: api/StockforProductinLocation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockforProductinLocation(int id, StockforProductinLocation stockforProductinLocation)
        {
            if (id != stockforProductinLocation.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(stockforProductinLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockforProductinLocationExists(id))
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

        // POST: api/StockforProductinLocation
        [HttpPost]
        public async Task<ActionResult<StockforProductinLocation>> PostStockforProductinLocation(StockforProductinLocation stockforProductinLocation)
        {
            _context.StockforProductinLocation.Add(stockforProductinLocation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StockforProductinLocationExists(stockforProductinLocation.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStockforProductinLocation", new { id = stockforProductinLocation.ProductId }, stockforProductinLocation);
        }

        // DELETE: api/StockforProductinLocation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockforProductinLocation>> DeleteStockforProductinLocation(int id)
        {
            var stockforProductinLocation = await _context.StockforProductinLocation.FindAsync(id);
            if (stockforProductinLocation == null)
            {
                return NotFound();
            }

            _context.StockforProductinLocation.Remove(stockforProductinLocation);
            await _context.SaveChangesAsync();

            return stockforProductinLocation;
        }

        private bool StockforProductinLocationExists(int id)
        {
            return _context.StockforProductinLocation.Any(e => e.ProductId == id);
        }
    }
}
