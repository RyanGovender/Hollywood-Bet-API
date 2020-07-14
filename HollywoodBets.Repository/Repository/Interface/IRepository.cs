using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Interface
{
   public interface IRepository<T>
    {
        bool Add(T item);
        IQueryable<T> GetAll();
        bool Update(T item);
        T Find(int? id);
        bool Delete(int? id);
    }
}
