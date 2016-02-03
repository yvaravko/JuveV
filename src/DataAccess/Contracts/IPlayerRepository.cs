using System.Collections.Generic;
using DataAccess.Domain;

namespace DataAccess.Contracts
{
    public interface IPlayerRepository : IBaseRepository<Player>, ISearchable<Player>
    {
        IEnumerable<Player> GetByCurrentTeam(Team team);

    }
}