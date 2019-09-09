using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toggler.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        //Task<IEnumerable<T>> GetAsync(Guid id);

        Task InsertAsync(T obj);
    }
}
