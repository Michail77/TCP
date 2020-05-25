using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Model
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public ApplicationDbContext() : base ()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bakalari;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //=> options.UseSqlite(@"Data Source=myDatabaseFile.sqlite");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .Property(p => p.Jmeno)
                .HasMaxLength(10);
            modelBuilder.Entity<Student>().HasData(new Student { Id = 1, Jmeno = "A", Prijmeni = "B" , ClassroomId=1},
                                                   new Student { Id = 2, Jmeno = "C", Prijmeni = "D" ,ClassroomId = 1 },
                                                   new Student { Id = 3, Jmeno = "E", Prijmeni = "F", ClassroomId = 2 },
                                                   new Student { Id = 4, Jmeno = "G", Prijmeni = "H", ClassroomId = 3 });
            modelBuilder.Entity<Classroom>().HasData(new Classroom { Id = 1, Nazev = "P1" },
                                                     new Classroom { Id = 2, Nazev = "P2" },
                                                     new Classroom { Id = 3, Nazev = "P3" },
                                                     new Classroom { Id = 4, Nazev = "P4" });
        }
    }
}
