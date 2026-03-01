using Microsoft.AspNetCore.Mvc;
using StoreMate.Context;
using StoreMate.Entities;

namespace StoreMate.Controllers
{
    public class ToDoController : Controller
    {
        private readonly StoreContext _context;

        public ToDoController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateTodo()
        {
            var todos = new List<ToDo>
    {
        new ToDo { Description = "Mail Gönder", Status = true, Priority = "Birinci" },
        new ToDo { Description = "Rapor Gönder", Status = true, Priority = "İkinci" },
        new ToDo { Description = "Toplantıda Sunum Yap", Status = false, Priority = "Birinci" }
    };

            _context.ToDos.AddRange(todos);
            _context.SaveChanges();
            return View();
        }
        public IActionResult ToDoAggreatePriority()
        {
            var PriF = _context.ToDos.Where(x => x.Priority == "Birinci").Select(y => y.Description).ToList();
            string result = PriF.Aggregate((acc, desc) => acc + "," + desc);
            ViewBag.results=result;
            return View();
        }
        public IActionResult ToDoChunk()
        {
            var values=_context.ToDos.Where(x=>!x.Status).ToList().Chunk(2).ToList();
            return View(values);

        }
    }
}
