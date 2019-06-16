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
    public class CompanyforPersonController : ControllerBase
    {
        private readonly lofyContext _context;

        public CompanyforPersonController(lofyContext context)
        {
            _context = context;
        }

        // GET: api/CompanyforPerson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyforPerson>>> GetCompanyforPerson()
        {
            return await _context.CompanyforPerson.ToListAsync();
        }

        // GET: api/CompanyforPerson/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyforPerson>> GetCompanyforPerson(int id)
        {
            var companyforPerson = await _context.CompanyforPerson.FindAsync(id);

            if (companyforPerson == null)
            {
                return NotFound();
            }

            return companyforPerson;
        }

        // PUT: api/CompanyforPerson/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyforPerson(int id, CompanyforPerson companyforPerson)
        {
            if (id != companyforPerson.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyforPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyforPersonExists(id))
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

        // POST: api/CompanyforPerson
        [HttpPost]
        public async Task<ActionResult<CompanyforPerson>> PostCompanyforPerson(CompanyforPerson companyforPerson)
        {
            _context.CompanyforPerson.Add(companyforPerson);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompanyforPersonExists(companyforPerson.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompanyforPerson", new { id = companyforPerson.Id }, companyforPerson);
        }

        // DELETE: api/CompanyforPerson/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyforPerson>> DeleteCompanyforPerson(int id)
        {
            var companyforPerson = await _context.CompanyforPerson.FindAsync(id);
            if (companyforPerson == null)
            {
                return NotFound();
            }

            _context.CompanyforPerson.Remove(companyforPerson);
            await _context.SaveChangesAsync();

            return companyforPerson;
        }

        private bool CompanyforPersonExists(int id)
        {
            return _context.CompanyforPerson.Any(e => e.Id == id);
        }
    }
}
