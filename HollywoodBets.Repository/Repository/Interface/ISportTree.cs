
using HollywoodBets.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Interface
{
    public interface ISportTree
    {
       IQueryable<SportTree> GetAll();
        bool Create(SportTree sportTree);
        bool Update(int? id, SportTree sportTree);
        bool Delete(int? id);
        SportTree Find(int? id); 
    }
}
