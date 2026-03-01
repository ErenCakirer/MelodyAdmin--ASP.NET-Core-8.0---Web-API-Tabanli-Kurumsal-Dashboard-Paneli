using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;

namespace StoreMate.ViewComponents
{
    public class Last5MessagesCP:ViewComponent
    {
        private readonly StoreContext _context;

        public Last5MessagesCP(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values=_context.messages.OrderBy(x=>x.MessageId).ToList().Take(5).ToList();
            return View(values);
        }
    }
}
