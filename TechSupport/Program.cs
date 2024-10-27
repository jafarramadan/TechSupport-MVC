using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechSupport.Data;
using TechSupport.Models;
using TechSupport.Repository.Interfaces;
using TechSupport.Repository.Services;

namespace TechSupport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // Get connection string from configuration.
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

            // Configure DbContext with SQL Server.
            builder.Services.AddDbContext<TechSupportDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add Identity services with Entity Framework.
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TechSupportDbContext>();
            // Register application services.

            builder.Services.AddScoped<IAccountx, IdentityAccountService>();



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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
