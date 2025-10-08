using Microsoft.AspNetCore.Mvc;

namespace Task4.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
