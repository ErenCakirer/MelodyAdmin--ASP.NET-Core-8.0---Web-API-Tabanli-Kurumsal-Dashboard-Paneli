using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;

namespace StoreMate.ViewComponents
{
    public class _ActivityDashboardCP:ViewComponent
    {
        private readonly StoreContext _context;
        public _ActivityDashboardCP(StoreContext context)
        {
           _context = context;
        }
        public IViewComponentResult Invoke()
        {
          var values=_context.Activitys.ToList();
            return View(values);
        }
    }
}
