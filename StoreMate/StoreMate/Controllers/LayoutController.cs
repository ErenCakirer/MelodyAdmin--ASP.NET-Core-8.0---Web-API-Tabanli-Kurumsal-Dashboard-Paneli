using Microsoft.AspNetCore.Mvc;

namespace StoreMate.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
