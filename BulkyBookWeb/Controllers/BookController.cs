using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using BulkyBookWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices bookServices;
        private readonly ICategoryServices categoryServices;

        #region ctor
        public BookController(IBookServices bookServices, ICategoryServices categoryServices)
        {
            this.bookServices = bookServices;
            this.categoryServices = categoryServices;
        }
        #endregion

        #region IndexAsync
        public async Task<IActionResult> Index()
        {
            var data = await bookServices.GetAllBooksAsyncWithCategory();

            return View(data);
        }
        #endregion


        #region create GET
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await categoryServices.GetAllCategoriesWithoutBookAsync(), "Id", "Name");
          
            return View();
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(book book)
        {
            
           
            if (ModelState.IsValid)
            {
                try
                {
                    var data = bookServices.CreatBookAsync(book);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                }
            }
            ViewBag.CategoryId = new SelectList(await categoryServices.GetAllCategoriesWithoutBookAsync(), "Id", "Name");
            return View(book);
        }
    }
}
