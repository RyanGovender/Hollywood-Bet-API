
using Dapper;
using HollywoodBets.DAL;
using HollywoodBets.Models.Custom_Models;
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
    public class IOddsRepository : IOdds
    {
        private IDb _dbService;
        public IOddsRepository(IDb dbService)
        {
            _dbService = dbService;
        }

        public IQueryable<MarketOdds> GetMarketOdds(int?tournamentId)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { tournamentId };
                return connection.Query<MarketOdds>("GetAllMarketsByTournaments",parameters,commandType:CommandType.StoredProcedure).AsQueryable();
            }
        }
    }
}
