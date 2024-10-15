using System;
using System.Collections.Generic;
using Hospital.Integratio.Deploy.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Integratio.Deploy.Context;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AreasMedica> AreasMedicas { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<EstadoTransaccione> EstadoTransacciones { get; set; }

    public virtual DbSet<Perfile> Perfiles { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<TipoTransaccion> TipoTransaccions { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:hospital-integration-server.database.windows.net,1433;Initial Catalog=Hospital-Ingtegracition-DB;Persist Security Info=False;User ID=darian;Password=Scorpion212121#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=300;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AreasMedica>(entity =>
        {
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasIndex(e => e.IdPaciente, "IX_Citas_IdPaciente");

            entity.HasIndex(e => e.IdServicio, "IX_Citas_IdServicio");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaAgendada).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Cita).HasForeignKey(d => d.IdPaciente);

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Cita).HasForeignKey(d => d.IdServicio);
        });

        modelBuilder.Entity<EstadoTransaccione>(entity =>
        {
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Perfile>(entity =>
        {
            entity.HasIndex(e => e.IdRol, "IX_Perfiles_IdRol");

            entity.HasIndex(e => e.IdUsuario, "IX_Perfiles_IdUsuario");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Perfiles).HasForeignKey(d => d.IdRol);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Perfiles).HasForeignKey(d => d.IdUsuario);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasIndex(e => e.IdAreaMedica, "IX_Servicios_IdAreaMedica");

            entity.HasIndex(e => e.IdTipoServicio, "IX_Servicios_IdTipoServicio");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.IdAreaMedicaNavigation).WithMany(p => p.Servicios).HasForeignKey(d => d.IdAreaMedica);

            entity.HasOne(d => d.IdTipoServicioNavigation).WithMany(p => p.Servicios).HasForeignKey(d => d.IdTipoServicio);
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.ToTable("TipoServicio");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<TipoTransaccion>(entity =>
        {
            entity.ToTable("TipoTransaccion");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasIndex(e => e.EstadoTransaccion, "IX_Transacciones_EstadoTransaccion");

            entity.HasIndex(e => e.IdCajero, "IX_Transacciones_IdCajero");

            entity.HasIndex(e => e.IdServicio, "IX_Transacciones_IdServicio").IsUnique();

            entity.HasIndex(e => e.TipoTransaccion, "IX_Transacciones_TipoTransaccion");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.EstadoTransaccion).HasDefaultValue(1);
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TipoTransaccion).HasDefaultValue(1);

            entity.HasOne(d => d.EstadoTransaccionNavigation).WithMany(p => p.Transacciones).HasForeignKey(d => d.EstadoTransaccion);

            entity.HasOne(d => d.IdCajeroNavigation).WithMany(p => p.Transacciones).HasForeignKey(d => d.IdCajero);

            entity.HasOne(d => d.IdServicioNavigation).WithOne(p => p.Transaccione).HasForeignKey<Transaccione>(d => d.IdServicio);

            entity.HasOne(d => d.TipoTransaccionNavigation).WithMany(p => p.Transacciones).HasForeignKey(d => d.TipoTransaccion);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Cedula).HasMaxLength(11);
            entity.Property(e => e.Clave).HasMaxLength(200);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Nombres).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
