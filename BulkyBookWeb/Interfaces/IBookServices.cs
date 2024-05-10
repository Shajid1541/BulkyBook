using BulkyBookWeb.Models;

namespace BulkyBookWeb.Interfaces
{
    public interface IBookServices
    {
        Task<List<book>> GetAllBooksAsync();
    }
}
