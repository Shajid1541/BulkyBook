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

        public BookController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            IEnumerable<book> obj = _db.books
                .Include(b=> b.Category);
            return View(obj);
        }

        public IActionResult Create()
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

            /*ViewBag.Categories = new SelectList(_db.Categories, "Id", "Name");
*/
            ViewBag.Categories = _db.Categories;
            return View(obj);
        }
    }
}
