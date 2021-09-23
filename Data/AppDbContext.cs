using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Defino cuales son las PK para Actor_Movie
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                //Estas son las FK de sus respectibas tablas
                am.ActorId, 
                am.MovieId
            });

            //Defino Actor_Movie para que sea mi tabla pivote
            //Defino las relaciones que tien la tabla Actor_Movie
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            /**
             * Vamos trabajar con la Entidad Actor_Movie, donde Movie tiene relacion en Uno con Actors_Movies y la clave foranea de esa relación es MovieId en Actors_Movies
             * Vamos trabajar con la Entidad Actor_Movie que tiene UN Movie el cual tiene Muchos Actors_Movies y la clave foranea de esta relación es MovieId en Actors_Movies
             * La entidad Actor_Movie N:1 Movie 
             * Actor_Movie tiene una Movie
             * Movie tiene muchas Actor_Movie */
            modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(a => a.ActorId);
            
            base.OnModelCreating(modelBuilder); //Define de manera automática las claves en las tablas.
        }

        //Definir el nombre de las tablas para cada modelo
        //          <Modelo> Nombre de la Tabla
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
