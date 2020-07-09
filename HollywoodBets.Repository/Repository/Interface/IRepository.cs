using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Interface
{
   public interface IRepository<T>
    {
        void Add(T item);
        IQueryable<T> GetAll();
        void Update(T item);
        T GetItem(int id);
        void Delete(int id);
    }
}
