using System.Linq;
using DataAccess.Domain;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Migrations;

namespace DataAccess
{
    public static class DbExtensions
    {
        public static void EnsureSeedData(this JuveDbContext ctx)
        {
            if (ctx.AllMigrationsApplied())
            {
                if (!ctx.PlayerTypes.Any())
                {
                    ctx.PlayerTypes.AddRange(
                        new PlayerType {Type = "Defender"},
                        new PlayerType {Type = "Midfield"},
                        new PlayerType {Type = "Forward"},
                        new PlayerType {Type = "Goalkeeper"}
                        );

                    ctx.SaveChanges();
                }

                if (!ctx.Countries.Any())
                {
                    ctx.Countries.AddRange(
                        new Country {Name = "Italy"},
                        new Country {Name = "Spain"},
                        new Country {Name = "France"},
                        new Country {Name = "England"},
                        new Country {Name = "Germany"}
                        );

                    ctx.SaveChanges();
                }

                if (!ctx.Teams.Any())
                {
                    var country = ctx.Countries.FirstOrDefault(x => x.Name == "Italy");
                    ctx.Teams.Add(new Team {Name = "Juventus", Country = country});
                    ctx.SaveChanges();
                }
            }
        }

        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
    }
}