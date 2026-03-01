using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;

namespace StoreMate.ViewComponents.StatisticsVC
{
    public class StatisticsCardVC:ViewComponent
    {
        private readonly StoreContext _context;

        public StatisticsCardVC(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.categoryCount = _context.Categories.Count();
            ViewBag.productMaxPrice=_context.Products.Max(x=>x.ProductPrice);
            ViewBag.productMinPrice = _context.Products.Min(x => x.ProductPrice);
            ViewBag.productMinPriceProductName = _context.Products.Where(x => x.ProductPrice == (_context.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
            ViewBag.productMaxPriceProductName=_context.Products.Where(x=>x.ProductPrice==(_context.Products.Max(y=>y.ProductPrice))).Select(z=>z.ProductName).FirstOrDefault();
            ViewBag.totalsumProStock=_context.Products.Sum (x=>x.ProductStock);
            ViewBag.avarageProStock=_context.Products.Average(x=>x.ProductStock);
            ViewBag.avarageProPrice = _context.Products.Average(x => x.ProductPrice);

            ViewBag.bgpthen1000Pc=_context.Products.Where(x=>x.ProductPrice>1000).Count();
            ViewBag.getıd4=_context.Products.Where(x=>x.ProductId==4).Select(x=>x.ProductName).FirstOrDefault();
            ViewBag.stocksmaller=_context.Products.Where(x=>x.ProductStock >20 && x.ProductStock<100).Count();            
                return View();
        }
    }
}
