using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using WireMockPOC.Models;
using WireMockPOC.Services;

namespace WireMockPOC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHackerNewsService hackerNewsService;

        public HomeController(ILogger<HomeController> logger, IHackerNewsService hackerNewsService)
        {
            _logger = logger;
            this.hackerNewsService = hackerNewsService;
        }

        public async Task<IActionResult> Index()
        {
            var stories = await this.hackerNewsService.GetTopTenStoriesAsync();

            return View(stories);
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
