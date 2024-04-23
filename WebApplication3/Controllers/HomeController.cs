using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public HomeController(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        public IList<Item> Item { get; set; } = default!;

        [Route("AdminPanel/AllItems")]
        public async Task<IList<Item>> OnGetAsync()
        {
            Item = await _context.Item.ToListAsync();
            return Item;
        }
        
    }
}
