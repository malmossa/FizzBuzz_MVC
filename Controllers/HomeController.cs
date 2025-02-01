using System.Diagnostics;
using FizzBuzz_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            FizzBuzz model = new FizzBuzz();

            model.FizzValue = 3;
            model.BuzzValue = 5;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
