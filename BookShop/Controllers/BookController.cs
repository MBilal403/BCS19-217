using BookShop.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookDbContext _context;

        public BookController(ILogger<HomeController> logger, BookDbContext context )
        {
            _logger = logger;
            _context = context;  
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(model);
                _context.SaveChanges();
            }
            
            return RedirectToAction("List","Book");
        }


        public IActionResult Edit()
        {
            
            return View();
        }
        public IActionResult Delete(int? id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
           
            return View(book);
        }

        public async Task<IActionResult> List()
        {
            var ls = new List<BookModel>();
             ls = await _context.Books.ToListAsync();
            return View(ls);
        }

        public IActionResult Details(int? id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            return View(book);
        }
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(string Title)
        {
            var book =await _context.Books.Where(x => x.Title.Contains(Title)).ToListAsync();
            
            return View("List", book);
        }

    }
}
