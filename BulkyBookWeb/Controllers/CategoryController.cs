using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices categoryServices;

        #region ctor
        public CategoryController(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(string? search="")
        {
            var data = await categoryServices.GetAllCategoriesAsync(search);

            return View(data);
        }
        #endregion

        #region create GET
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region create POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and Order cannot be Same!");
            }
            if (ModelState.IsValid)
            {
                var data = await categoryServices.CreateCategoryAsync(obj);
                if(data != null)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(obj);
        }
        #endregion

        #region edit GET
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var data = await categoryServices.GetCategoryAsync(id);
                return View(data);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            
        }
        #endregion

        #region edit POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and Order cannot be Same!");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await categoryServices.UpdateCategoryAsync(obj);
                    TempData["success"] = "Successfully Edited";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(obj);
                }
            }

            return View(obj);
        }
        #endregion

        #region delete GET
        public async Task<IActionResult> Delete(int id=0)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            try
            {
                var data = await categoryServices.GetCategoryAsync(id);
                return View(data);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region delete POST
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeletePost(int id=0)
        {
            if(id == 0)
            {
                return NotFound();
            }
            try
            {
                var data = await categoryServices.DeleteCategoryAsync(id);
                TempData["success"] = "Successfully Deleted";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            
        }
        #endregion

        #region buybook
        public async Task<IActionResult> buy(int id)
        {
            try
            {
                var data = await categoryServices.UpdateBuyOne(id);
                return RedirectToAction("Index", "Book");
            }
            catch(Exception ex)
            {
                return NotFound();
            }
            
        }
        #endregion

    }
}
