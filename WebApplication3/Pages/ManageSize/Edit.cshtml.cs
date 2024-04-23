using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Pages.ManageSize
{
    public class EditModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public EditModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public SizeTable SizeTable { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {

            var sizetable =  await _context.SizeTable.FirstOrDefaultAsync(m => m.Id == 1);
            if (sizetable == null)
            {
                return NotFound();
            }
            SizeTable = sizetable;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SizeTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeTableExists(SizeTable.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SizeTableExists(int id)
        {
            return _context.SizeTable.Any(e => e.Id == id);
        }
    }
}
