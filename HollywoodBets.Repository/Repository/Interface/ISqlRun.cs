using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Interface
{
    public interface ISqlRun <T>
    {
       IQueryable<T> RunSql(string sqlFormat);
    }
}
