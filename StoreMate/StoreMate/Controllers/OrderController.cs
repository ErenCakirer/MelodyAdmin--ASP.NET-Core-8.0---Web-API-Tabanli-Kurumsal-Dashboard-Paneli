using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreMate.Context;

namespace StoreMate.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreContext _context;

        public OrderController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult AllStockSmallerThen5()
        {
            bool orderstockCount = _context.Orders.All(x => x.OrderCount <= 5);
            if (orderstockCount)
            {
                ViewBag.v = "Tüm Siparişler 5 adetten az.";
            }
            else
            {
                ViewBag.v = "Siparişler 5 adetten fazla.";
            }
                return View();
        }
        
        public async Task<IActionResult> OrderListAsync2()
        {
            var values = await _context.Orders.Include(x => x.Product).Include(y => y.Customer).ToListAsync();
            return View(values);
        }
        public async Task<IActionResult> CreateOrder()
        {
       
            var products = await _context.Products.Select(p => new SelectListItem
            {
                Value = p.ProductId.ToString(),
                Text = p.ProductName
            }).ToListAsync();

            ViewBag.products = products;

            
            var customers = await _context.Customers.Select(c => new SelectListItem
            {
                Value = c.CustomerId.ToString(),
                Text = c.CustomerName + " " + c.CustomerSurname
            }).ToListAsync();

            ViewBag.customers = customers;

            return View();
        }
    }
}
