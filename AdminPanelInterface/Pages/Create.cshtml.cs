using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelInterface.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AdminPanelInterface.Pages
{
    public class CreateModel : PageModel
    {
        public CreateModel()
        {
            Item = new Item();
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Item Item { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            URL uRL = new URL();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uRL.Url);

                var json = JsonConvert.SerializeObject(Item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Items", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error creating item: " + response.StatusCode);
                    return Page();
                }
            }
        }
    }
}
