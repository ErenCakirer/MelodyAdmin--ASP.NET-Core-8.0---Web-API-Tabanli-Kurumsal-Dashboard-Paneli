using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreMate.Context;

namespace StoreMate.Controllers
{
    public class MessageController : Controller
    {
        private readonly StoreContext _context;

        public MessageController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
            var values=_context.messages.AsNoTracking().ToList();
            return View(values);
        }
        public IActionResult ProductCount()
        {
            var lastProduct = _context.Products.OrderBy(x => x.ProductId).Last();
            ViewBag.v22=lastProduct.ProductName;
            return View();
        }
    }
}
