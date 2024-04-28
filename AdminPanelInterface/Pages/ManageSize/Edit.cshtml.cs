using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanelInterface.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication3.Models;

namespace WebApplication3.Pages.ManageSize
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [BindProperty]
        public SizeTable SizeTable { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            URL uRL = new URL();
            var response = await _httpClient.GetAsync($"{uRL.Url}SizeTables/1");
            response.EnsureSuccessStatusCode();
            SizeTable = await response.Content.ReadFromJsonAsync<SizeTable>();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            URL uRL = new URL();
            var response = await _httpClient.PutAsJsonAsync($"{uRL.Url}SizeTables/1", SizeTable);
            response.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}
