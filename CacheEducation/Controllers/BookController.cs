using Microsoft.AspNetCore.Mvc;

namespace CacheEducation.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
