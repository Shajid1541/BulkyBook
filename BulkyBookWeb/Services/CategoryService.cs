using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repos;

namespace BulkyBookWeb.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly IBulky<Category, int, Category> categoryRepo;

        public CategoryService(IBulky<Category, int, Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            var data = await categoryRepo.Create(category);
            return data;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            return await categoryRepo.Delete(categoryId);
        }

        public async Task<view> GetAllCategoriesAsync(string search)
        {
            var data = new view();
            data.Categories = await categoryRepo.GetAll();
            data.search = search;
            return data;
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            var data = await categoryRepo.Read(categoryId);
            return data;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var data = await categoryRepo.Update(category);
            return data;
        }
    }
}
