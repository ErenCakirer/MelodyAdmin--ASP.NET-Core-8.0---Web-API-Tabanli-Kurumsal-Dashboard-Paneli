using Microsoft.AspNetCore.Mvc;

namespace StoreMate.ViewComponents
{
    public class _ThemeSettingsDashboard:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
