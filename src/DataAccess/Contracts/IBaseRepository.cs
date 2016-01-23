using System.Collections.Generic;
using DataAccess.Domain;

namespace DataAccess.Contracts
{
    public interface IBaseRepository<T> where T : BaseEntityWithId
    {
        T GetById(int id);

        IEnumerable<T> GetList();

        void Update(T entity);

        void Delete(int id);

        int Create(T entity);
    }
}