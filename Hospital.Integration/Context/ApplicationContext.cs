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
        public DbSet<AreasMedicas> AreasMedicas { get; set; }
        public DbSet<Citas> Citas { get; set; }
        public DbSet<EstadoTransaccion> EstadoTransacciones { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<TipoServicio> TipoServicio { get; set; }
        public DbSet<TipoTransaccion> TipoTransaccion { get; set; }
        public DbSet<Transacciones> Transacciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Citas>()
                .Property(e => e.Estado)
                .HasDefaultValue(true);

            modelBuilder.Entity<Citas>()
                .Property(e => e.FechaAgendada)
                .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<AreasMedicas>()
                .Property(e => e.Estado)
                .HasDefaultValue(true);

            modelBuilder.Entity<EstadoTransaccion>()
                .Property(e => e.Estado)
                .HasDefaultValue(true);
            modelBuilder.Entity<EstadoTransaccion>()
                .HasData(new EstadoTransaccion() 
                {
                    Id =1,
                    Descripcion = "pending"
                });
            modelBuilder.Entity<EstadoTransaccion>()
                .HasData(new EstadoTransaccion()
                {
                    Id = 2,
                    Descripcion = "applied"
                });
            modelBuilder.Entity<EstadoTransaccion>()
                .HasData(new EstadoTransaccion()
                {
                    Id = 3,
                    Descripcion = "rollback"
                });
            modelBuilder.Entity<Perfiles>()
                .Property(e => e.Estado)
                .HasDefaultValue(true);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Estado)
                .HasDefaultValue(true);

            modelBuilder.Entity<Servicios>()
                .Property(e => e.Estado)
                .HasDefaultValue(true);

            modelBuilder.Entity<TipoServicio>()
                .Property(e => e.Estado)
                .HasDefaultValue(true);

            modelBuilder.Entity<TipoServicio>()
                .HasData(new TipoServicio() 
                {
                    Id=1,
                    Descripcion="Analisis"
                });
            modelBuilder.Entity<TipoServicio>()
                .HasData(new TipoServicio()
                {
                    Id = 2,
                    Descripcion = "Procedimiento"
                });

            modelBuilder.Entity<TipoTransaccion>()
                .Property(e => e.Estado)
                .HasDefaultValue(true);
            modelBuilder.Entity<TipoTransaccion>()
                .HasData(new TipoTransaccion() 
                {
                    Id = 1,
                    Descripcion = "CashInflow"
                });
            modelBuilder.Entity<TipoTransaccion>()
                .HasData(new TipoTransaccion()
                {
                    Id = 2,
                    Descripcion = "CashOutflow"
                });
            modelBuilder.Entity<TipoTransaccion>()
                .HasData(new TipoTransaccion()
                {
                    Id = 3,
                    Descripcion = "ServicePayment"
                });

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.Estado)
                .HasDefaultValue(true);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.TipoTransaccion)
                .HasDefaultValue(1);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.EstadoTransaccion)
                .HasDefaultValue(1);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.Fecha)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Estado)
                .HasDefaultValue(true);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
