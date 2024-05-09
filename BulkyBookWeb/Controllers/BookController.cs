using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _db;
        private readonly AppDbContext _context;
        public BookController(AppDbContext db)
        {
            _db = db;
            _context = _db;
        }
        public IActionResult Index()
        {
            
            IEnumerable<book> obj = _db.books
                .Include(b=> b.Category);
            return View(obj);
        }

        /*public IActionResult Create()
        {
            ViewBag.Categories = _db.Categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(bookDTO obj)
        {
            
            if (ModelState.IsValid)
            {
                var cat = _db.Categories.Find(obj.cid);
                book book = new book();
                book.Name = obj.Name;
                book.Price = obj.Price;
                book.Category = cat;
                _db.books.Add(book);
                _db.SaveChanges();
                TempData["success"] = "Successfully Created";
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _db.Categories;
            return View(obj);
        }*/
        // GET: Book/Create
        public IActionResult Create()
        {
            
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            var chk = ViewBag.CategoryId;
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(book book)
        {
            /*if (book.cid != null)
            {
                book.Category = _context.Categories.FirstOrDefault(x => x.Id == book.cid).;
            }
            var chk = ModelState;*/
           /* foreach (var modelStateKey in ModelState.Keys)
            {
                var modelStateVal = ModelState[modelStateKey];
                foreach (var error in modelStateVal.Errors)
                {
                    var errorMessage = error.ErrorMessage;
                    // Log or inspect the error message here
                }
            }*/
            if (ModelState.IsValid)
            {
                
                _context.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", book.cid);
            return View(book);
        }
    }
}
