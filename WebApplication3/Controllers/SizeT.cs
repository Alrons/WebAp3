using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Pages;
using static WebApplication3.Pages.ManageSize.IndexModel;

namespace WebApplication3.Controllers
{
    public class SizeT : Controller
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public SizeT(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }


        public SizeTable SizeTable { get; set; } = default!;

        [Route("ManageSize/SizeTable")]
        public async Task<SizeTable?> OnGetAsync()
        {
            var sizetable = await _context.SizeTable.FirstOrDefaultAsync(m => m.Id == 1);
            SizeTable = sizetable;
            return SizeTable;
        }
    }
}
