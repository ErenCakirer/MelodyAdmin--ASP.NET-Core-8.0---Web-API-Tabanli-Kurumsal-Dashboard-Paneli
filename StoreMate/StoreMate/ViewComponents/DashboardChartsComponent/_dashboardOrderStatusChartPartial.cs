using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;
using StoreMate.Models;

namespace StoreMate.ViewComponents.DashboardChartsComponent
{
    public class _dashboardOrderStatusChartPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _dashboardOrderStatusChartPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var result=_context.Orders.GroupBy(o=>o.Status).Select(g=>new OrderStatus
            {
                Status=g.Key,
                Count=g.Count()
                
            }).ToList();
            return View(result);
        }
    }
}
