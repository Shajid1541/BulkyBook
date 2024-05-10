using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace BulkyBookWeb.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<book> books { get; set; }
    }
}
