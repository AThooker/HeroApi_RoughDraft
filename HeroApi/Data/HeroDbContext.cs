using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HeroDbContext : DbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options)
        {    }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Villian> Villians { get; set; }
    }
}