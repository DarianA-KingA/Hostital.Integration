using Hospital.Integration.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hospital.Integration.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        public DbSet<Cita> Citas { get; set; }

        public DbSet<Transacciones> Transacciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
