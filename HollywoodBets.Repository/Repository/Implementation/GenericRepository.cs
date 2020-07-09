using HollywoodBets.DAL;

using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Implementation
{
    public class GenericRepository <T> where T:class, IGeneric<T>
    {
        private IDb _dbService;
        private DbSet<T> _dbSet;

        public GenericRepository(IDb dbService)
        {
            _dbService = dbService;
            _dbSet = _dbService.dBContext().Set<T>();
        }

        public IQueryable<T> GetAll(string sqlStatement)
        {
            return _dbSet.FromSqlRaw($"{sqlStatement}");
        }
    }
}
