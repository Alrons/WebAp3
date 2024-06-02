using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataA.Data;
using DataA.Models;

namespace DataA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurTablesController : ControllerBase
    {
        private readonly DataAContext _context;

        public OurTablesController(DataAContext context)
        {
            _context = context;
        }

        // GET: api/OurTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OurTables>>> GetOurTables()
        {
            return await _context.OurTables.ToListAsync();
        }

        // GET: api/OurTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OurTables>> GetOurTables(int id)
        {
            var ourTables = await _context.OurTables.FindAsync(id);

            if (ourTables == null)
            {
                return NotFound();
            }

            return ourTables;
        }

        // PUT: api/OurTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOurTables(int id, OurTables ourTables)
        {
            if (id != ourTables.Id)
            {
                return BadRequest();
            }

            _context.Entry(ourTables).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OurTablesExists(id))
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

        // POST: api/OurTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OurTables>> PostOurTables(OurTables ourTables)
        {
            _context.OurTables.Add(ourTables);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOurTables", new { id = ourTables.Id }, ourTables);
        }

        // DELETE: api/OurTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOurTables(int id)
        {
            var ourTables = await _context.OurTables.FindAsync(id);
            if (ourTables == null)
            {
                return NotFound();
            }

            _context.OurTables.Remove(ourTables);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OurTablesExists(int id)
        {
            return _context.OurTables.Any(e => e.Id == id);
        }
    }
}
