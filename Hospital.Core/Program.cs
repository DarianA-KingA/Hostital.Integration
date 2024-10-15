using Hospital.Core.Context;
using Hospital.Core.Models;
using Hospital.Core.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hospital.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.ConfigureApplicationCookie(options => {
                options.LoginPath = $"/User/Login";
                options.LogoutPath = $"/User/Login";
                options.AccessDeniedPath = $"/User/Login";
                options.ExpireTimeSpan = TimeSpan.FromDays(14); // Duración de la cookie de autenticación
                options.SlidingExpiration = true;
            });
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options => {

                options.IdleTimeout = TimeSpan.FromMinutes(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            using (var scope = app.Services.CreateScope())
            {
                var DbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                DbInitializer.Seed();
            }

            app.UseAuthentication(); // Habilitar la autenticación
            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            // app.MapRazorPages();    

            app.Run();
        }
    }

}
