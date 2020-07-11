using Dapper;
using HollywoodBets.DAL;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { betTypeId};
                return connection.Query<Market>("GetMarketsForBetType",parameters,commandType:CommandType.StoredProcedure).AsQueryable();
            }
        }

        public IQueryable<Market> RunSql(string sqlFormat)
        {
            return _dbService.dBContext().Market.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }
    }
}
