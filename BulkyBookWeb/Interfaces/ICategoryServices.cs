using BulkyBookWeb.Models;

namespace BulkyBookWeb.Interfaces
{
    public interface ICategoryServices
    {
       
        Task<view> GetAllCategoriesAsync(string search);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> GetCategoryAsync(int categoryId);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int categoryId);
        Task<List<Category>> GetAllCategoriesWithoutBookAsync();
        Task<Category> UpdateBuyOne(int categoryId);
    }
}
