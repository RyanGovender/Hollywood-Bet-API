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
    public class BetTypeRepository :IBetType , ISqlRun<BetType>
    {
        private IDb _dbService;
        public BetTypeRepository(IDb dbService)
        {
            _dbService = dbService;
        }

        public IQueryable<BetType> GetBetTypesForTournament(int? tournamentId)
        {
            return RunSql($"EXECUTE dbo.GetBetTypesForTournament {tournamentId}");
        }

        public IQueryable<BetType> RunSql(string sqlFormat)
        {
            return _dbService.dBContext().BetType.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }
    }
}
