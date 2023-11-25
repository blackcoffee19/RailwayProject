using Microsoft.AspNetCore.Mvc;
using RailwayProject.Models;
using System.Diagnostics;

namespace RailwayProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public RailwayDBContext ctx { get; set; }

        public HomeController(ILogger<HomeController> logger, RailwayDBContext ctx)
        {
            _logger = logger;
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SearchRoute( )
        {
            
            return View();
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