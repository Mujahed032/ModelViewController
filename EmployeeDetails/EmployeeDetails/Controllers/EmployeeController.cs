using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetails.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
