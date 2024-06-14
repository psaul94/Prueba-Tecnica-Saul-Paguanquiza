using Persistencia.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Entity
{
    public class GamerDbContext : DbContext
    {
        public GamerDbContext(DbContextOptions<GamerDbContext> options) : base(options)
        {
        }
        public DbSet<Gamer> Gamers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<Gamer>().HasKey(x => x.Name);

            // Inserting record in OurHero table
            modelBuilder.Entity<Gamer>().HasData(
                new Gamer
                {
                    Name = "Leo",
                    Amount = 100 
                }
            );
        }
    }
}

