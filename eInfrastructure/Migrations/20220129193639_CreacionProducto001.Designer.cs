﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eInfrastructure.Contexts;

namespace eInfrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220129193639_CreacionProducto001")]
    partial class CreacionProducto001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("eInfrastructure.Entities.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescripcionEstado")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdEstado");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            IdEstado = 1,
                            DescripcionEstado = "USUARIO ACTIVO"
                        },
                        new
                        {
                            IdEstado = 2,
                            DescripcionEstado = "USUARIO BLOQUEADO"
                        },
                        new
                        {
                            IdEstado = 99,
                            DescripcionEstado = "USUARIO BORRADO"
                        });
                });

            modelBuilder.Entity("eInfrastructure.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioRegistro")
                        .HasColumnType("int");

                    b.Property<string>("IdiomaElegido")
                        .IsRequired()
                        .HasColumnType("varchar(3) CHARACTER SET utf8mb4")
                        .HasMaxLength(3);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("esAdministrador")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdEstado");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            Cedula = "ADM001",
                            Contraseña = "$2a$11$cj7GAUkP8V9hgkPv7z8G6.1c4DMrX8eeTH8JaSYHnfZv.G/ZjKvzO",
                            Correo = "vicram10@gmail.com",
                            FechaRegistro = new DateTime(2022, 1, 29, 16, 36, 38, 738, DateTimeKind.Local).AddTicks(9700),
                            IdEstado = 1,
                            IdUsuarioRegistro = 1,
                            IdiomaElegido = "ES",
                            Nombre = "ADMINISTRADOR GENERAL",
                            esAdministrador = true
                        });
                });

            modelBuilder.Entity("eInfrastructure.Entities.Usuario", b =>
                {
                    b.HasOne("eInfrastructure.Entities.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
