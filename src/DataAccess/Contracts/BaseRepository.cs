using System.Collections.Generic;
using System.Linq;
using DataAccess.Domain;
using Microsoft.Data.Entity;

namespace DataAccess.Contracts
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntityWithId
    {
        private readonly JuveDbContext _context;

        public BaseRepository()
        {
            _context = new JuveDbContext();
        }

        public T GetById(int id)
        {
            return GetDbSet().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetList()
        {
            return GetDbSet().ToList();
        }

        public DbSet<T> GetDbSet()
        {
            return _context.Set<T>();
        }
    }
}