using BookingSystem.DataModel.Master.Menu;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingSystem.WEB.Components
{
    public class NavMenuViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NavMenuViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new List<IndexMenu>();
            var client = _httpClientFactory.CreateClient();
            var url = "http://localhost:5156/api/Menu";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                try
                {
                    model = JsonSerializer.Deserialize<List<IndexMenu>>(responseString, options);
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }

            return View(model);
        }
    }
}
