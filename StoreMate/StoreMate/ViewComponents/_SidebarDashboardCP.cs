using Microsoft.AspNetCore.Mvc;

namespace StoreMate.ViewComponents
{
    public class _SidebarDashboardCP:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
