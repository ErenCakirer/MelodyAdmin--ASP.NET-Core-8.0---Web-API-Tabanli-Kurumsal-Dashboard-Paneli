using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;
using StoreMate.Models;

namespace StoreMate.ViewComponents
{
    public class _DailySalesDashboardCP:ViewComponent
    {
        private readonly StoreContext _context;

        public _DailySalesDashboardCP(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context.ToDos.GroupBy(t => t.Priority).Select(g => new ToDoStatusChartVM
            {
                Status = g.Key,
                Count = g.Count()
            }).ToList();
            return View(data);
        }
    }
}
