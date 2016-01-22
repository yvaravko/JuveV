using DataAccess.Contracts;
using DataAccess.Domain;

namespace DataAccess.Repos
{
    public class PlayerTypeRepository : BaseRepository<PlayerType>, IPlayerTypeRepository<PlayerType>
    {
    }
}