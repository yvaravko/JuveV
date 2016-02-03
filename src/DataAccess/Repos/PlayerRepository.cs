using System.Collections.Generic;
using System.Linq;
using DataAccess.Contracts;
using DataAccess.Domain;
using Microsoft.Data.Entity;

namespace DataAccess.Repos
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public override IEnumerable<Player> GetList()
        {
            return DbSet()
				.Include(x => x.Country)
				.Include(x => x.PlayerType)
				.Include(x => x.CurrentTeam);
        }

        public IEnumerable<Player> GetByCurrentTeam(Team team)
        {
            return DbSet()
                .Include(x => x.Country)
                .Include(x => x.PlayerType)
                .Include(x => x.CurrentTeam).Where(x => x.CurrentTeamId == team.Id);
        }

        public override Player GetById(int id)
        {
            return DbSet()
                .Include(x => x.Country)
                .Include(x => x.PlayerType)
                .Include(x => x.CurrentTeam).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Player> Search(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return GetList();
            }

            int id;
            if (int.TryParse(value, out id))
            {
                return new[] { GetById(id) };
            }

            return DbSet().Include(x => x.Country).Where(x => x.LastName.Contains(value) || x.Country.Name == value);
        }
    }
}