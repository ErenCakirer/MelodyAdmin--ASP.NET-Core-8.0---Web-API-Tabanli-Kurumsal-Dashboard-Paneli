using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;

namespace StoreMate.ViewComponents
{
    public class _ToDoDashboardCP:ViewComponent
    {
        private readonly StoreContext _context;

        public _ToDoDashboardCP(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values=_context.ToDos.OrderByDescending(x=>x.ToDoId).Take(6).ToList();
            return View(values);
        }
    }
}
