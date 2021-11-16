using IceCreamProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamProject.Controllers
{
    public class HomeController : Controller
    {
        static string LayoutName = "Layout";
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly OrdersContext _context;
        public HomeController(OrdersContext context)
        {
            _context = context;
        }

        public IActionResult ShowGraph()
        {
            //mockup data
            List<Temprature> values = new List<Temprature> { };
            foreach (var item in _context.Order)
            {
                values.Add(new Temprature { Id = item.Id, Month = item.Date.Month.ToString(), TempValue = (((int)item.FeelsLike)) });
            }

            return View(values);
        }

        public IActionResult Index()
        {
            ViewData["Layout"] = LayoutName; 
            return View();
        }


        public IActionResult ChangeUserMode(string layoutName)
        {
            LayoutName = layoutName;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
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
