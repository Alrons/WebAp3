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
    public class AddedItemsController : ControllerBase
    {
        private readonly DataAContext _context;

        public AddedItemsController(DataAContext context)
        {
            _context = context;
        }

        // GET: api/AddedItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddedItems>>> GetAddedItems()
        {
            return await _context.AddedItems.ToListAsync();
        }

        // GET: api/AddedItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddedItems>> GetAddedItems(int id)
        {
            var addedItems = await _context.AddedItems.FindAsync(id);

            if (addedItems == null)
            {
                return NotFound();
            }

            return addedItems;
        }

        // PUT: api/AddedItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddedItems(int id, AddedItems addedItems)
        {
            if (id != addedItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(addedItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddedItemsExists(id))
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

        // POST: api/AddedItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddedItems>> PostAddedItems(AddedItems addedItems)
        {
            _context.AddedItems.Add(addedItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddedItems", new { id = addedItems.Id }, addedItems);
        }

        // DELETE: api/AddedItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddedItems(int id)
        {
            var addedItems = await _context.AddedItems.FindAsync(id);
            if (addedItems == null)
            {
                return NotFound();
            }

            _context.AddedItems.Remove(addedItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddedItemsExists(int id)
        {
            return _context.AddedItems.Any(e => e.Id == id);
        }
    }
}
