﻿using eInfrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///insertamos valores por defecto
            ///
            modelBuilder.Entity<Estado>().HasData(

                new Estado[]
                {
                    new Estado{IdEstado = 1, DescripcionEstado = "USUARIO ACTIVO"},

                    new Estado{IdEstado = 2, DescripcionEstado = "USUARIO BLOQUEADO"},

                    new Estado{IdEstado = 99, DescripcionEstado = "USUARIO BORRADO"},
                }
            );

            ///usuario administrador
            ///
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario[]
                {
                    new Usuario{

                        IdUsuario=1,

                        Cedula = "ADM001",

                        Nombre = "ADMINISTRADOR GENERAL",

                        IdEstado = 1,//Activo 
                        
                        Contraseña = BCrypt.Net.BCrypt.HashPassword("aa.123456"), //@@edigital.2021 (Produccion), aa.123456 (Desarrollo)
                        
                        IdUsuarioRegistro = 1,

                        FechaRegistro = DateTime.Now,

                        IdiomaElegido = "ES",

                        Correo = "vicram10@gmail.com",

                        esAdministrador = true
                    }
                }
            );
        }
    }
}
