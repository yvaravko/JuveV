using DataAccess.Domain;

namespace DataAccess.Contracts
{
    public interface IPlayerTypeRepository<T> : IBaseRepository<T> where T : BaseEntityWithId
    {
    }
}