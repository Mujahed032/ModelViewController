using Microsoft.AspNetCore.Mvc;

namespace MVC_RunGroopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
