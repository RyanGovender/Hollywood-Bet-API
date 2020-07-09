
using HollywoodBets.Models.Model;
using HollywoodBets.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.DAL
{
    public class DatabaseService : IDb
    {
        private HollywoodBetsDBContext _dbContext;
        public DatabaseService(HollywoodBetsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public HollywoodBetsDBContext dBContext()
        {
            return _dbContext;
        }
    }
}
