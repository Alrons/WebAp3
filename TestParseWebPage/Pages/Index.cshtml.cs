using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AllItems;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace TestParseWebPage.Pages
{
    public class IndexModel : PageModel

    {

        static readonly HttpClient client = new HttpClient();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            List<Items> items = new List<Items>();
            var task = client.GetAsync("https://localhost:7139/api/Items");
            HttpResponseMessage result = task.Result;
            if(result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                items = Items.FromJson(jsonString).ToList();
            }
            
            ViewData["items"] = items;
            
        }
    }
}
