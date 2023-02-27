﻿// <auto-generated />
using System;
using Infrastructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructura.Data.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Cuenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("NumeroCuenta")
                        .HasColumnType("int");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TipoCuenta")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("fechaModificacion")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("Core.Entities.Movimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CuentaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaMovimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TipoMovimiento")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("fechaModificacion")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CuentaId");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("Core.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .HasColumnType("longtext");

                    b.Property<string>("Identificacion")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("fechaModificacion")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.HasBaseType("Core.Entities.Persona");

                    b.Property<string>("Contrasena")
                        .HasColumnType("longtext");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Core.Entities.Cuenta", b =>
                {
                    b.HasOne("Core.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Core.Entities.Movimiento", b =>
                {
                    b.HasOne("Core.Entities.Cuenta", "Cuenta")
                        .WithMany()
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });
#pragma warning restore 612, 618
        }
    }
}
