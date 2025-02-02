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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(FizzBuzz model)
        {
            List<string> fbItems = new List<string>();

            bool fizz;
            bool buzz;

            for(int i = 1; i <= 100; i++)
            {
                fizz = (i % model.FizzValue == 0);
                buzz = (i % model.BuzzValue == 0);

                if (fizz == true && buzz == true)
                {
                    fbItems.Add("FizzBuzz");
                } else if (fizz == true)
                {
                    fbItems.Add("Fizz");
                } else if (buzz == true)
                {
                    fbItems.Add("Buzz");
                } else
                {
                    fbItems.Add(i.ToString());
                }
            }

            model.Results = fbItems;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
