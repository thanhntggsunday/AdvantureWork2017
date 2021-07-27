using AdvantureWork.Common.Provider;
using Microsoft.AspNetCore.Mvc;

namespace AdvantureWork.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoggerManager _logger;

        public HomeController(ILoggerManager logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Logging ...");

            return Ok("ok");
        }

        public IActionResult Privacy()
        {
            return Ok("ok");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Ok("ok");
        }
    }
}