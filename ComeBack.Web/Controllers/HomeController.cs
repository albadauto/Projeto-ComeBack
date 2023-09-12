using ComeBack.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ComeBack.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;
        private IHttpClientFactory _client;
        private string apiUrl;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IHttpClientFactory client)
        {
            _logger = logger;
            _configuration = configuration;
            _client = client;
            apiUrl = $"{_configuration.GetValue<string>("APIURL")}/User/GetAllUsers";
        }

        public async Task<IActionResult> Index()
        {
            var factory = _client.CreateClient();
            var response = await factory.GetAsync(apiUrl);
            var result = await response.Content.ReadAsStringAsync();
            var listOfUsers = JsonConvert.DeserializeObject<List<User>>(result);
            return View(listOfUsers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}