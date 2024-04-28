using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using SimpleJSON;
using AllItems;

namespace WebApplication3.Pages.AdminPanel
{
    public class IndexModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public IList<Items> Item { get;set; } = default!;

        public async Task OnGetAsync()
        {
            List<Items> items = new List<Items>();
            var task = client.GetAsync("https://localhost:7139/api/Items");
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                Item = Items.FromJson(jsonString).ToList();
            }

            ViewData["items"] = items;
        }
    }
}
