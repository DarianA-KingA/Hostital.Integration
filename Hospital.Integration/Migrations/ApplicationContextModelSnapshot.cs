﻿// <auto-generated />
using System;
using Hospital.Integration.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital.Integration.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hospital.Integration.Models.AreasMedicas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("AreasMedicas");
                });

            modelBuilder.Entity("Hospital.Integration.Models.Citas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("FechaAgendada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<int>("IdServicio")
                        .HasColumnType("int");

                    b.Property<int>("IdTransaccion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdServicio");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Hospital.Integration.Models.EstadoTransaccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("EstadoTransacciones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "pending",
                            Estado = false
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "applied",
                            Estado = false
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "rollback",
                            Estado = false
                        });
                });

            modelBuilder.Entity("Hospital.Integration.Models.Perfiles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdRol");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Perfiles");
                });

            modelBuilder.Entity("Hospital.Integration.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Hospital.Integration.Models.Servicios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("IdAreaMedica")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoServicio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAreaMedica");

                    b.HasIndex("IdTipoServicio");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Hospital.Integration.Models.TipoServicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("TipoServicio");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Analisis",
                            Estado = false
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Procedimiento",
                            Estado = false
                        });
                });

            modelBuilder.Entity("Hospital.Integration.Models.TipoTransaccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("TipoTransaccion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "CashInflow",
                            Estado = false
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "CashOutflow",
                            Estado = false
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "ServicePayment",
                            Estado = false
                        });
                });

            modelBuilder.Entity("Hospital.Integration.Models.Transacciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("EstadoTransaccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IdCajero")
                        .HasColumnType("int");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<int>("IdServicio")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<int>("TipoTransaccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("EstadoTransaccion");

                    b.HasIndex("IdCajero");

                    b.HasIndex("IdServicio")
                        .IsUnique();

                    b.HasIndex("TipoTransaccion");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("Hospital.Integration.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UltimaModificacion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Hospital.Integration.Models.Citas", b =>
                {
                    b.HasOne("Hospital.Integration.Models.Usuario", "Usuario")
                        .WithMany("Citas")
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Integration.Models.Servicios", "Servicios")
                        .WithMany("Citas")
                        .HasForeignKey("IdServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servicios");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Hospital.Integration.Models.Perfiles", b =>
                {
                    b.HasOne("Hospital.Integration.Models.Roles", "Roles")
                        .WithMany("Perfiles")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Integration.Models.Usuario", "Usuario")
                        .WithMany("Perfiles")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Hospital.Integration.Models.Servicios", b =>
                {
                    b.HasOne("Hospital.Integration.Models.AreasMedicas", "AreasMedicas")
                        .WithMany("Servicios")
                        .HasForeignKey("IdAreaMedica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Integration.Models.TipoServicio", "TipoServicio")
                        .WithMany("Servicios")
                        .HasForeignKey("IdTipoServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AreasMedicas");

                    b.Navigation("TipoServicio");
                });

            modelBuilder.Entity("Hospital.Integration.Models.Transacciones", b =>
                {
                    b.HasOne("Hospital.Integration.Models.EstadoTransaccion", "EstadoTransacciones")
                        .WithMany("Transacciones")
                        .HasForeignKey("EstadoTransaccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Integration.Models.Usuario", "Cajero")
                        .WithMany()
                        .HasForeignKey("IdCajero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Integration.Models.Servicios", "Servicios")
                        .WithOne("Transacciones")
                        .HasForeignKey("Hospital.Integration.Models.Transacciones", "IdServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Integration.Models.TipoTransaccion", "TipoTransacciones")
                        .WithMany("Transacciones")
                        .HasForeignKey("TipoTransaccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cajero");

                    b.Navigation("EstadoTransacciones");

                    b.Navigation("Servicios");

                    b.Navigation("TipoTransacciones");
                });

            modelBuilder.Entity("Hospital.Integration.Models.AreasMedicas", b =>
                {
                    b.Navigation("Servicios");
                });

            modelBuilder.Entity("Hospital.Integration.Models.EstadoTransaccion", b =>
                {
                    b.Navigation("Transacciones");
                });

            modelBuilder.Entity("Hospital.Integration.Models.Roles", b =>
                {
                    b.Navigation("Perfiles");
                });

            modelBuilder.Entity("Hospital.Integration.Models.Servicios", b =>
                {
                    b.Navigation("Citas");

                    b.Navigation("Transacciones")
                        .IsRequired();
                });

            modelBuilder.Entity("Hospital.Integration.Models.TipoServicio", b =>
                {
                    b.Navigation("Servicios");
                });

            modelBuilder.Entity("Hospital.Integration.Models.TipoTransaccion", b =>
                {
                    b.Navigation("Transacciones");
                });

            modelBuilder.Entity("Hospital.Integration.Models.Usuario", b =>
                {
                    b.Navigation("Citas");

                    b.Navigation("Perfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
