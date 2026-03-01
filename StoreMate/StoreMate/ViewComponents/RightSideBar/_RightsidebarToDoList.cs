using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;

namespace StoreMate.ViewComponents.RightSideBar
{
    public class _RightsidebarToDoList:ViewComponent
    {
        private readonly StoreContext _context;

        public _RightsidebarToDoList(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values=_context.ToDos.OrderBy(x=>x.ToDoId).ToList().TakeLast(10).ToList();
             return View(values);
        }
    }
}
