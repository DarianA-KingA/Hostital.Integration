using Hospital.Core.Context;
using Hospital.Core.Models;
using Hospital.Core.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog;

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
                options.ExpireTimeSpan = TimeSpan.FromDays(7); // Duraci�n de la cookie de autenticaci�n
                options.SlidingExpiration = true;
            });
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options => {

                options.IdleTimeout = TimeSpan.FromMinutes(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug() // Establecer el nivel m�nimo de log
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // Sobrescribir nivel para categor�as espec�ficas
            .Enrich.FromLogContext() // Enriquecer los logs con el contexto actual
            .WriteTo.Console() // Opci�n de escribir en consola
            .WriteTo.MSSqlServer(
                connectionString: builder.Configuration.GetConnectionString("DefaultConnection"), // Cambia por tu cadena de conexi�n
                sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true }, // Crear autom�ticamente la tabla
                restrictedToMinimumLevel: LogEventLevel.Information // Nivel m�nimo para SQL Server
            )
            .CreateLogger();
            builder.Services.AddHealthChecks();
            Log.Information("Iniciando integracion");
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
            app.UseAuthentication(); // Habilitar la autenticaci�n
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                // Endpoint para health check
                endpoints.MapHealthChecks("/health");
            });

            //using (var scope = app.Services.CreateScope())
            //{
            //    var DbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            //    DbInitializer.Seed();
            //}

            
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            // app.MapRazorPages();    

            app.Run();
        }
    }

}
