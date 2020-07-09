
using HollywoodBets.DAL;
using HollywoodBets.Models.Custom_Models;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return _dbService.dBContext().MarketOdds.FromSqlInterpolated($"EXECUTE dbo.GetAllMarketsByTournaments {tournamentId}");
        }
    }
}
