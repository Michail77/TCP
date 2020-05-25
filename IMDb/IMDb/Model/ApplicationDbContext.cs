using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Model
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Film> Filmy { get; set; }
        public DbSet<Herec> Herci { get; set; }
        public DbSet<HerecFilm> HerecFilmy { get; set; }

        public ApplicationDbContext() : base()
        {
            //Database.Create();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HerecFilm>().HasKey(hf => new { hf.FilmId, hf.HerecId });
            modelBuilder.Entity<Herec>().HasData(new Herec { Id = 1, Jmeno = "Jim", Prijmeni = "Carrey" });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 1, Nazev = "Maska", Hodnoceni = 8 });
            modelBuilder.Entity<HerecFilm>().HasData(new HerecFilm { FilmId = 1, HerecId = 1 });
        }
    }
}
