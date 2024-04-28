using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanelInterface.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models;

namespace WebApplication3.Pages.ManageSize
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public SizeTable SizeTable { get; set; }

        public async Task OnGetAsync()
        {
            URL uRL = new URL();

            var response = await _httpClient.GetAsync($"{uRL.Url}SizeTables");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadFromJsonAsync<IEnumerable<SizeTable>>();
            SizeTable = responseBody.FirstOrDefault();
        }
    }
}
