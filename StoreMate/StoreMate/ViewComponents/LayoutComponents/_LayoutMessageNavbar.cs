using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StoreMate.Context;

namespace StoreMate.ViewComponents.LayoutComponents
{
    public class _LayoutMessageNavbar : ViewComponent
    {
        private readonly StoreContext _context;

        public _LayoutMessageNavbar(StoreContext context)
        {
            _context = context;
        }

      
        public IViewComponentResult Invoke()
        {
            var values = _context.messages
                                 .Where(y => y.IsRead == false)
                                 .OrderByDescending(x => x.MessageId)
                                 .Take(3)
                                 .ToList();

            ViewBag.messageCount = _context.messages.Count(x => x.IsRead == false);

            return View(values);
        }
    }
}
