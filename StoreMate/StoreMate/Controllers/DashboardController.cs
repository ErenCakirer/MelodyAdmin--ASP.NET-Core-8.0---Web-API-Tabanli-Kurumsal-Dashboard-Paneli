using Microsoft.AspNetCore.Mvc;

namespace StoreMate.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Statistics()
        {
            return View();
        }
    }
}
