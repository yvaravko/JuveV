using System.Collections.Generic;

namespace DataAccess.Contracts
{
    public interface ISearchable<T>
    {
        IEnumerable<T> Search(string value);
    }
}