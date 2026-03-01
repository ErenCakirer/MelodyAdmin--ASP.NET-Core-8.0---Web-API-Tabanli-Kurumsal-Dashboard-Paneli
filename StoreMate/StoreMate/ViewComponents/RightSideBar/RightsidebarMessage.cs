// Sınıf isminin sonuna ViewComponent ekledik
using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;

public class RightsidebarMessageViewComponent : ViewComponent
{
    private readonly StoreContext _context;
    public RightsidebarMessageViewComponent(StoreContext context) => _context = context;

    public IViewComponentResult Invoke()
    {
        var values = _context.messages.OrderByDescending(x => x.MessageId).ToList().Take(2).ToList();
        return View(values);
    }
}