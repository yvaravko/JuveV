using DataAccess.Domain;

namespace DataAccess.Contracts
{
    public interface ITeamRepository : IBaseRepository<Team>, ISearchable<Team>
    {
    }
}