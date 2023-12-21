using CV_storage.Core.Models;
using CV_storage.Core.Services;
using CV_storage.Data;
using CV_storage.Services;
using Microsoft.EntityFrameworkCore;

namespace CV_storage_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CvDbContext>(options => 
                options.UseSqlite(builder.Configuration.GetConnectionString("cv-storage"))
            );
            builder.Services.AddTransient<IDbService, DbService>();
            builder.Services.AddTransient<IEntityService<CurriculumVitae>, EntityService<CurriculumVitae>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}