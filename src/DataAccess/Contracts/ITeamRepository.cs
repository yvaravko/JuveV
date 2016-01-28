using System.Collections.Generic;
using DataAccess.Domain;

namespace DataAccess.Contracts
{
    public interface ITeamRepository : IBaseRepository<Team>
    {
        IEnumerable<Team> Search(string value);
    }
}