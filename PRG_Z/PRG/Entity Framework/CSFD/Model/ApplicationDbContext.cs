using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSFD.Model
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public ApplicationDbContext() : base()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSFD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<MovieActor>().HasKey(ma => new { ma.MovieId, ma.ActorId });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 1, Name = "Pulp Fiction" }, new Movie { Id = 2, Name = "Pulp Fiction 2" });
            modelBuilder.Entity<Actor>().HasData(new Actor { Id = 1, FirstName = "Samuel L.", LastName = "Jackson" }, new Actor { Id = 2, FirstName = "Samuel A.", LastName = "Jackson" });
            modelBuilder.Entity<MovieActor>().HasData(new MovieActor { MovieId = 1, ActorId = 1 }, new MovieActor { MovieId = 2, ActorId = 2 });
        }
    }
}
