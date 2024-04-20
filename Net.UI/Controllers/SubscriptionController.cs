using Microsoft.AspNetCore.Mvc;
using Net.UI.Data;
using System.Text.Json;
using System.Text;
using Net.UI.Models.DTO;

namespace Net.UI.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly NetDbContext netDbContext;
        private readonly IHttpClientFactory httpClientFactory;

        public SubscriptionController(NetDbContext netDbContext, IHttpClientFactory httpClientFactory)
        {
            this.netDbContext = netDbContext;
            this.httpClientFactory = httpClientFactory;
        }


       

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SendSubscription()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> SendSubscription(SubscriptionPostDto send)
        {
            var client = httpClientFactory.CreateClient();


            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7233/api/Subscription"),
                Content = new StringContent(JsonSerializer.Serialize(send), Encoding.UTF8, "application/json")
            };
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);


            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<SubscriptionPostDto>();

            if (response is not null)
            {


                return RedirectToAction("Index", "Home");

            }

            return View("Index" , "Home");

        }







    }
}
