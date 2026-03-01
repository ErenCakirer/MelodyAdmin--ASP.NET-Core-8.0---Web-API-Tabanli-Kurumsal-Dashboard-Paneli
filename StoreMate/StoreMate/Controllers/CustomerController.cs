using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;
using StoreMate.Entities;
using StoreMate.Models;

namespace StoreMate.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreContext _context;

        public CustomerController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult CustomerListOrderByCustomerName()
        {
            var values = _context.Customers.OrderBy(x=>x.CustomerName).ToList();
            return View(values);
        }
        public IActionResult CustomerGetByCity(string city)
        {
            var exist=_context.Customers.Any(x=>x.CustomerCity == city);
            if (exist)
            {
                ViewBag.message=$"{city} şehrinde en az 1 müşteri var.";  
            }
            else
            {
                ViewBag.message = $"{city} şehrinde hiç müşteri yok.";
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
           
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            _context.Customers.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        public IActionResult CustomerListByCity()
        {
            var groupedCustomers=_context.Customers.ToList().GroupBy(c=>c.CustomerCity).ToList();
            return View(groupedCustomers);
        }
        public IActionResult CustomersByCityCount()
        {
            var query = from c in _context.Customers
                        group c by c.CustomerCity into cityGroup
                        select new CustomerCityGroup
                        {
                            City = cityGroup.Key,
                            CustomerCount = cityGroup.Count()
                        };
            var model=query.ToList();
            return View(model);
        }
        public IActionResult CustomerListWithIndex()
        {
            var customers = _context.Customers.ToList().Select((c, index) => new
            {

                SiraNo=index+1,
                c.CustomerName,
                c.CustomerSurname,
                c.CustomerCity
            }).ToList();
            return View(customers);
        }
    }
}
