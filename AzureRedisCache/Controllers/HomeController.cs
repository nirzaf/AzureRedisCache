using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace AzureRedisCache.Controllers
{
    public class HomeController : Controller
    {
        private IDistributedCache _cache;

        public HomeController(IDistributedCache cache)
        {
            _cache = cache;
        }
        public IActionResult Index()
        {
           string test = _cache.GetString("Test") ?? "";
            if (string.IsNullOrEmpty( test))
            {
                _cache.SetString("Test", "Tested");
                test = _cache.GetString("Test") ?? "";
            }
            ViewData["Test"] = test;
            return View();
        }

        public IActionResult About()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Contact()
        {
            throw new System.NotImplementedException();
        }
    }
}
