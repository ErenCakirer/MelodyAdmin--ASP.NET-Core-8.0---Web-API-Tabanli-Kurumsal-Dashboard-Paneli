using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;
using StoreMate.Models;

namespace StoreMate.ViewComponents
{
    public class _SalesStatusDashboardCP:ViewComponent
    {
        private readonly StoreContext _context;

        public _SalesStatusDashboardCP(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            {
                var data=_context.Customers.GroupBy(x=>x.CustomerCity).Select(g=>new CustomersChartsVm
                {
                    City=g.Key,
                    Count=g.Count()
                }).ToList();
                return View(data);
            }
        }
    }
}
