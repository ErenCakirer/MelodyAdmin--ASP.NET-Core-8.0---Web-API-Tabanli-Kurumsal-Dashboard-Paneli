using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;

namespace StoreMate.ViewComponents.LayoutComponents
{
    public class _LayoutToDoNavbar:ViewComponent
    {
        private readonly StoreContext _context;

        public _LayoutToDoNavbar(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values=_context.ToDos.Where(y=>y.Status==false).OrderByDescending(x=>x.ToDoId).Take(4).ToList();
            ViewBag.toto = _context.ToDos.Count();
            return View(values);
        }
    }
}
