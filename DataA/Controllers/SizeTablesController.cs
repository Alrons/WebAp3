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
    public class SizeTablesController : ControllerBase
    {
        private readonly DataAContext _context;

        public SizeTablesController(DataAContext context)
        {
            _context = context;
        }

        // GET: api/SizeTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeTable>>> GetSizeTable()
        {
            return await _context.SizeTable.ToListAsync();
        }

        // GET: api/SizeTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeTable>> GetSizeTable(int id)
        {
            var sizeTable = await _context.SizeTable.FindAsync(id);

            if (sizeTable == null)
            {
                return NotFound();
            }

            return sizeTable;
        }

        // PUT: api/SizeTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeTable(int id, SizeTable sizeTable)
        {
            if (id != sizeTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(sizeTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeTableExists(id))
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
        private bool SizeTableExists(int id)
        {
            return _context.SizeTable.Any(e => e.Id == id);
        }
    }
}
