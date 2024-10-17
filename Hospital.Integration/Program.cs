
using Hospital.Integration.Context;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System;

namespace Hospital.Integration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug() // Establecer el nivel mínimo de log
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // Sobrescribir nivel para categorías específicas
            .Enrich.FromLogContext() // Enriquecer los logs con el contexto actual
            .WriteTo.Console() // Opción de escribir en consola
            .WriteTo.MSSqlServer(
                connectionString: "Server=LAPTOP-U18PB02K;Database=TempHospitalDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;", // Cambia por tu cadena de conexión
                sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true }, // Crear automáticamente la tabla
                restrictedToMinimumLevel: LogEventLevel.Information // Nivel mínimo para SQL Server
            )
            .CreateLogger();

            Log.Information("Iniciando la aplicación web");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
