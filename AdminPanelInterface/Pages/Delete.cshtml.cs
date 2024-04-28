using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdminPanelInterface.Models;

namespace AdminPanelInterface.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [BindProperty]
        public Item Item { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            URL uRL = new URL();

            var response = await _httpClient.GetAsync($"{uRL.Url}Items/{id}");
            if (response.IsSuccessStatusCode)
            {
                Item = await response.Content.ReadFromJsonAsync<Item>();
            }
            else
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            URL uRL = new URL();

            var response = await _httpClient.DeleteAsync($"{uRL.Url}Items/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
