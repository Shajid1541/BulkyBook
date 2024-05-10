using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repos;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Services
{
    public class BookService : IBookServices
    {
        private readonly IBulky<book, int, book> bookRepo;
    

        public BookService(IBulky<book, int,book> bookRepo)
        {
            this.bookRepo = bookRepo;

        }

        public async Task<book> CreatBookAsync(book book)
        {
            return await bookRepo.Create(book);
        }

        public async Task<List<book>> GetAllBooksAsync()
        {
            return await bookRepo.GetAll();
        }

        public async Task<List<book>> GetAllBooksAsyncWithCategory()
        {
            if(bookRepo is BookRepo bookExpRepo)
            {
                return await bookExpRepo.GetAllWithCategory();
            }
            return await bookRepo.GetAll();
        }
    }
}
