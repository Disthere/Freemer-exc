using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);
        
        T Get(int id);

        Task<List<T>> Select();

        bool Delete(T entity);

    }
}
