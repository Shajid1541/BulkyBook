using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Repos
{
    public class CategoryRepo : IBulky<Category, int, Category>
    {
        private readonly AppDbContext db;

        public CategoryRepo(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Category> Create(Category type)
        {
            db.Categories.Add(type);
            if (db.SaveChanges() > 0) return await Task.FromResult(type);
            else return null;
        }

        public async Task<bool> Delete(int type)
        {
            try
            {
                db.Categories.Remove(db.Categories.Find(type));
                db.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<List<Category>> GetAll()
        {

            return await db.Categories.ToListAsync();
        }

        public async Task<Category> Read(int iD)
        {
            return await db.Categories.FindAsync(iD);
        }

        public async Task<Category> Update(Category type)
        {
            try
            {
                db.Categories.Update(type);
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
