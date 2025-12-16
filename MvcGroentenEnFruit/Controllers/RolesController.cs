using Microsoft.AspNetCore.Mvc;

namespace MvcGroentenEnFruit.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
