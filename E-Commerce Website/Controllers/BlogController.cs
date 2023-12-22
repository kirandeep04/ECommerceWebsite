using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Website.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
