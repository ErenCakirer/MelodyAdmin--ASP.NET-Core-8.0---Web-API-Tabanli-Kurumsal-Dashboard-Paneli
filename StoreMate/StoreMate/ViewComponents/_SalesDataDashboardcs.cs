using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreMate.Context;

namespace StoreMate.ViewComponents
{
    public class _SalesDataDashboardcs:ViewComponent
    {
        private readonly StoreContext _context;

        public _SalesDataDashboardcs(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values=_context.Orders.OrderByDescending(z=>z.OrderId).Include(x=>x.Customer).Include(y=>y.Product).Take(5).ToList();
            return View(values);
        }
    }
}
