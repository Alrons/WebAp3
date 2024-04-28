using AdminPanelInterface.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanelInterface.Pages
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditModel(IHttpClientFactory httpClientFactory)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            URL uRL = new URL();

            var response = await _httpClient.PutAsJsonAsync($"{uRL.Url}Items/{Item.Id}", Item);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
