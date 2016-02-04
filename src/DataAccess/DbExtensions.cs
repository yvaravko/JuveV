using System;
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
                    ctx.Teams.Add(new Team {Name = "Juventus", CountryId = country.Id, Country = country});
                    ctx.SaveChanges();
                }

                if (!ctx.Players.Any())
                {
                    var country = ctx.Countries.FirstOrDefault(x => x.Name == "Italy");
                    var type = ctx.PlayerTypes.FirstOrDefault(x => x.Type == "GoalKeeper");
                    var team = ctx.Teams.FirstOrDefault(x => x.Name == "Juventus");
                    var buffon = new Player
                    {
                        PlayerType = type,
                        PlayerTypeId = type.Id,
                        TeamNumber = 1,
                        FirstName = "Gianluidgi",
                        LastName = "Buffon",
                        Country = country,
                        CountryId = country.Id,
                        CurrentTeam = team,
                        CurrentTeamId = team.Id,
                        BirthDate = new DateTime(1978, 1, 28),
                        StartDate = new DateTime(2000, 1, 1)
                    };

                    ctx.Players.Add(buffon);
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