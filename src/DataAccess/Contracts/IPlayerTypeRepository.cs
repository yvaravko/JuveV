using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Domain;

namespace DataAccess.Contracts
{
    public interface IPlayerTypeRepository<T> : IBaseRepository<T> where T : BaseEntityWithId
    {
    }
}
