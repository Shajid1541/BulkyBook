using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repos;

namespace BulkyBookWeb
{
    public class DataAccessFactory
    {
        public static IBulky<book, int, book> bookData(AppDbContext db)
        {
            return new BookRepo(db);
        }
    }
}
