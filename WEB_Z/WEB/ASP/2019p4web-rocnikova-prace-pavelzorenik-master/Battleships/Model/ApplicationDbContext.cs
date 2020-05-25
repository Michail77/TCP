using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Battleships.Model
{
    public class ApplicationDbContext : IdentityDbContext<Player>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerGame> PlayerGames { get; set; }
        public DbSet<BoardPiece> BoardPieces { get; set; }
        public DbSet<Ship> Ships { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BoardPiece>()
                .HasOne(bp => bp.Ship)
                .WithMany()
                .HasForeignKey(bp => bp.ShipId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
