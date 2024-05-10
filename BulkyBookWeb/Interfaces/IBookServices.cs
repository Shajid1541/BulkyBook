using BulkyBookWeb.Models;

namespace BulkyBookWeb.Interfaces
{
    public interface IBookServices
    {
        Task<List<book>> GetAllBooksAsync();
        Task<book> CreatBookAsync(book book);
        Task<List<book>> GetAllBooksAsyncWithCategory();
    }
}
