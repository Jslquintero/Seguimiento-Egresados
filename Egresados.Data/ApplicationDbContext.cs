using Egresados.Common;
using Egresados.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Egresados.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<BolsaTrabajo> BolsaTrabajo { get; set; }
        public virtual DbSet<CentroEducativo> CentroEducativo { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Facultad> Facultad { get; set; }
        public virtual DbSet<LugarEvento> LugarEvento { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SeedDatabase(builder);
        }

        private void SeedDatabase(ModelBuilder builder)
        {
            // builder.Entity<Pais>()
            //            .HasData(
            //                 new Pais() { Id = 1, Nombre = "Panamá", Codigo = "PTY", FechaAlta = DateTime.Now},
            //                 new Pais() { Id = 2, Nombre = "Colombia", Codigo = "CO", FechaAlta = DateTime.Now}

            // );

            builder.Entity<Provincia>()
           .HasData(
                new Provincia() { Id = 1, Nombre = "Herrera", Codigo = "06", FechaAlta = DateTime.Now },
                new Provincia() { Id = 2, Nombre = "Los Santos", Codigo = "07", FechaAlta = DateTime.Now }

                );

            builder.Entity<LugarEvento>()
          .HasData(
               new LugarEvento() { Id = 1, Nombre = "Hotel Azuero", Codigo = "HTAzuero", FechaAlta = DateTime.Now },
               new LugarEvento() { Id = 2, Nombre = "UTP Azuero", Codigo = "CRA", FechaAlta = DateTime.Now }

               );

            builder.Entity<Evento>()
        .HasData(
             new Evento() { Id = 1, Nombre = "Evento 1",Sala="1", Costo=10.4M,Descripcion="evento de prueba", HoraEvento=DateTime.Now,FechaAlta=DateTime.Now, FechaEvento=DateTime.Now,
             LugarEventoId=1, FacultadId=1},
             new Evento() { Id = 2, Nombre = "Evento 2",Sala="2", Costo=10.4M,Descripcion="evento de prueba", HoraEvento=DateTime.Now,FechaAlta=DateTime.Now, FechaEvento=DateTime.Now,
             LugarEventoId=1, FacultadId=1}


             );

            builder.Entity<Facultad>()
         .HasData(
           new Facultad() { Id = 1, Nombre = "Sistemas", Codigo = "FISC", FechaAlta = DateTime.Now, CentroId=1 },
           new Facultad() { Id = 2, Nombre = "Civil", Codigo = "FIC", FechaAlta = DateTime.Now, CentroId=1 }
           );

            builder.Entity<CentroEducativo>()
          .HasData(
               new CentroEducativo() { Id = 1, Nombre = "Centro Regional de Azuero", Codigo = "CRA", FechaAlta = DateTime.Now }
               );



        }
    }
}
