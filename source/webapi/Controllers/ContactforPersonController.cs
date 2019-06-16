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
    public class ContactforPersonController : ControllerBase
    {
        private readonly lofyContext _context;

        public ContactforPersonController(lofyContext context)
        {
            _context = context;
        }

        // GET: api/ContactforPerson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactforPerson>>> GetContactforPerson()
        {
            return await _context.ContactforPerson.ToListAsync();
        }

        // GET: api/ContactforPerson/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactforPerson>> GetContactforPerson(int id)
        {
            var contactforPerson = await _context.ContactforPerson.FindAsync(id);

            if (contactforPerson == null)
            {
                return NotFound();
            }

            return contactforPerson;
        }

        // PUT: api/ContactforPerson/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactforPerson(int id, ContactforPerson contactforPerson)
        {
            if (id != contactforPerson.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(contactforPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactforPersonExists(id))
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

        // POST: api/ContactforPerson
        [HttpPost]
        public async Task<ActionResult<ContactforPerson>> PostContactforPerson(ContactforPerson contactforPerson)
        {
            _context.ContactforPerson.Add(contactforPerson);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactforPersonExists(contactforPerson.PersonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContactforPerson", new { id = contactforPerson.PersonId }, contactforPerson);
        }

        // DELETE: api/ContactforPerson/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactforPerson>> DeleteContactforPerson(int id)
        {
            var contactforPerson = await _context.ContactforPerson.FindAsync(id);
            if (contactforPerson == null)
            {
                return NotFound();
            }

            _context.ContactforPerson.Remove(contactforPerson);
            await _context.SaveChangesAsync();

            return contactforPerson;
        }

        private bool ContactforPersonExists(int id)
        {
            return _context.ContactforPerson.Any(e => e.PersonId == id);
        }
    }
}
