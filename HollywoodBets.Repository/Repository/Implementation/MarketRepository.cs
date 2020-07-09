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
    public class MarketRepository : IMarket,ISqlRun<Market>
    {
        private IDb _dbService;
        public MarketRepository(IDb dbService)
        {
            _dbService = dbService;
        }

        public IQueryable<Market> GetMarketsForBetType(int? betTypeId)
        {
            return RunSql($"EXECUTE dbo.GetMarketsForBetType {betTypeId}");
        }

        public IQueryable<Market> RunSql(string sqlFormat)
        {
            return _dbService.dBContext().Market.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }
    }
}
