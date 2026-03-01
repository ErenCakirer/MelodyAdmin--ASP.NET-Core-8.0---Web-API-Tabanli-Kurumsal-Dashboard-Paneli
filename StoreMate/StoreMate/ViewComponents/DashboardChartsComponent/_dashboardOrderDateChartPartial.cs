using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;
using StoreMate.Models;

namespace StoreMate.ViewComponents.DashboardChartsComponent
{
    public class _dashboardOrderDateChartPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _dashboardOrderDateChartPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            
            var rawData = _context.Orders
                .GroupBy(o => o.OrderDate.Date)
                .Select(g => new
                {
                    Tarih = g.Key,
                    Adet = g.Count()
                })
                .ToList();

        
            var data = rawData.Select(x => new OrderDate
            {
                Date = x.Tarih.ToString("yyyy-MM-dd"),
                Count = x.Adet
            })
            .OrderBy(x => x.Date)
            .ToList();

            return View(data);
        }
    }
}
