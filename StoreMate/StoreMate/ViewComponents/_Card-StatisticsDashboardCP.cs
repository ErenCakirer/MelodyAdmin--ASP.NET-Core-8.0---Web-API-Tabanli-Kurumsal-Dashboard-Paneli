using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;

namespace StoreMate.ViewComponents
{
    public class _Card_StatisticsDashboardCP:ViewComponent
    {
        private readonly StoreContext _context;

        public _Card_StatisticsDashboardCP(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.totalCustomerCount = _context.Customers.Count();
            ViewBag.totalCategoryCount = _context.Categories.Count();
            ViewBag.totalProductCount = _context.Products.Count();
            ViewBag.avgCustomerBalance=_context.Customers.Average(x=>x.CustomerBalance);
            ViewBag.totalorderCount= _context.Orders.Count();
            ViewBag.sumorderProductCount = _context.Orders.Sum(X => X.OrderCount);
            return View();
        }
    }
}
