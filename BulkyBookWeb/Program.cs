using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repos;
using BulkyBookWeb.Services;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            AddScoping(builder);


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //add database connetction
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));



            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static void AddScoping(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBulky<book, int, book>, BookRepo>();
            builder.Services.AddScoped<IBulky<Category, int, Category>, CategoryRepo>();
            builder.Services.AddScoped<IBookServices, BookService>();
            builder.Services.AddScoped<ICategoryServices, CategoryService>();
        }
    }
}