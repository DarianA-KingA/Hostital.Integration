using Hospital.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Core.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<AreasMedicas> AreasMedicas { get; set; }
        public DbSet<Citas> Citas { get; set; }
        public DbSet<EstadoTransaccion> EstadoTransacciones { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<TipoServicio> TipoServicio { get; set; }
        public DbSet<TipoTransaccion> TipoTransaccion { get; set; }
        public DbSet<Transacciones> Transacciones { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }

}
