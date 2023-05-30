using DILife.Models;
using DILife.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DILife.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;
        public HomeController(ITransientService transientService1, ITransientService transientService2,
        IScopedService scopedService1,IScopedService scopedService2,
        ISingletonService singletonService1, ISingletonService singletonService2)
        {
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
        }
        public IActionResult Index()
        {
            ViewBag.message1 = "First Instance: " + _transientService1.GetGuid().ToString();
            ViewBag.message2 = "Second Instance: " + _transientService2.GetGuid().ToString();
            ViewBag.message3 = "First Instance: " + _scopedService1.GetGuid().ToString();
            ViewBag.message4 = "Second Instance: " + _scopedService2.GetGuid().ToString();
            ViewBag.message5 = "First Instance: " + _singletonService1.GetGuid().ToString();
            ViewBag.message6 = "Second Instance: " + _singletonService2.GetGuid().ToString();
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
