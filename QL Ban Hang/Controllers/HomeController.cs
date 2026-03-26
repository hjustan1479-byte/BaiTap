using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QL_Ban_Hang.Models;

namespace QL_Ban_Hang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Books = BookRepository.GetAll(),
                Categories = BookRepository.GetCategoryCounts()
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var book = BookRepository.GetById(id);

            if (book is null)
            {
                return NotFound();
            }

            return View(book);
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
