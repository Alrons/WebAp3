using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AllItems;
using AdminPanelInterface.Models;

namespace AdminPanelInterface.Pages
{
    public class IndexModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public IList<Items> Item { get; set; } = default!;

        public async Task OnGetAsync()
        {
            URL uRL = new URL();
            List<Items> items = new List<Items>();

            var task = client.GetAsync($"{uRL.Url}Items");
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
