using System.Collections.Generic;
using System.Linq;
using DataAccess.Contracts;
using DataAccess.Domain;
using Microsoft.Data.Entity;

namespace DataAccess.Repos
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public override IEnumerable<Team> GetList()
        {
            return DbSet().Include(x => x.Country);
        }

        public IEnumerable<Team> Search(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return GetList();
            }

            int id;
            if (int.TryParse(value, out id))
            {
                return new[] {GetById(id)};
            }

            return DbSet().Include(x => x.Country).Where(x => x.Name.Contains(value) || x.Country.Name == value);
        }

        public override Team GetById(int id)
        {
            return DbSet().Include(x => x.Country)
				.FirstOrDefault(x => x.Id == id);
        }
    }
}