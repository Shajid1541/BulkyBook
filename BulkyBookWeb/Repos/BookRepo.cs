using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Repos
{
    internal class BookRepo : IBulky<book, int, book>
    {
        private readonly AppDbContext db;

        public BookRepo(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<book> Create(book type)
        {
            db.books.Add(type);
            if (db.SaveChanges() > 0) return await Task.FromResult(type);
            else return null;
        }

        public async Task<bool> Delete(int type)
        {
            try
            {
                db.books.Remove(db.books.Find(type));
                db.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<List<book>> GetAll()
        {
            
            return await db.books.ToListAsync();
        }

        public async Task<book> Read(int iD)
        {
            return await db.books.FindAsync(iD);
        }

        public async Task<book> Update(book type)
        {
            try
            {
                db.books.Update(type);
                db.SaveChanges();
                return await Task.FromResult(type);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
    }
}
