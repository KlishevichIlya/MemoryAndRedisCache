using Microsoft.AspNetCore.Mvc;

namespace CacheEducation.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
