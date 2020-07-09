using HollywoodBets.DAL;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Implementation
{
    public class SportTreeRepository : ISportTree , ISqlRun<SportTree>
    {
        private IDb _dbService;
      

        public SportTreeRepository(IDb dBContext)
        {
            _dbService = dBContext;
          
        }

        public IQueryable<SportTree> GetAll()
        {
          
            return RunSql($"EXECUTE dbo.GetAllSports"); 
        }
        public IQueryable<SportTree> RunSql(string sqlFormat)
        {
            return _dbService.dBContext().SportTree.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }


    }
}
