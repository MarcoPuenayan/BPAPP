﻿// <auto-generated />
using System;
using BPAPP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BPAPP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220529154650_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BPAPP.Data.Cliente", b =>
                {
                    b.Property<Guid>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersona");

                    b.HasIndex("IdCliente")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BPAPP.Data.Cuenta", b =>
                {
                    b.Property<Guid>("IdCuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<Guid?>("IdCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCuenta");

                    b.HasIndex("IdCliente");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("BPAPP.Data.Movimiento", b =>
                {
                    b.Property<Guid>("IdMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IdCuenta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoMovimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdMovimiento");

                    b.HasIndex("IdCuenta");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("BPAPP.Data.Cuenta", b =>
                {
                    b.HasOne("BPAPP.Data.Cliente", "Clientes")
                        .WithMany("Cuentas")
                        .HasForeignKey("IdCliente");

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("BPAPP.Data.Movimiento", b =>
                {
                    b.HasOne("BPAPP.Data.Cuenta", "Cuentas")
                        .WithMany("Movimientos")
                        .HasForeignKey("IdCuenta");

                    b.Navigation("Cuentas");
                });

            modelBuilder.Entity("BPAPP.Data.Cliente", b =>
                {
                    b.Navigation("Cuentas");
                });

            modelBuilder.Entity("BPAPP.Data.Cuenta", b =>
                {
                    b.Navigation("Movimientos");
                });
#pragma warning restore 612, 618
        }
    }
}
