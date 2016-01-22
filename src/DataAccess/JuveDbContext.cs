using DataAccess.Domain;
using Microsoft.Data.Entity;

namespace DataAccess
{
    public class JuveDbContext : DbContext
    {
        public JuveDbContext()
        {
            //Database.EnsureCreated();
        }

        public DbSet<PlayerType> PlayerTypes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JuveV;Integrated Security=True";

            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}