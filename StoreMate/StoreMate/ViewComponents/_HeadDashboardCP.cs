using Microsoft.AspNetCore.Mvc;

namespace StoreMate.ViewComponents
{
    public class _HeadDashboardCP:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
