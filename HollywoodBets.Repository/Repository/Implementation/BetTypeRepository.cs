using Dapper;
using HollywoodBets.DAL;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
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
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new {tournamentId};
                return connection.Query<BetType>("GetBetTypesForTournament",parameters,commandType:CommandType.StoredProcedure).AsQueryable();
            }
           
        }

        public IQueryable<BetType> RunSql(string sqlFormat)
        {
            return _dbService.dBContext().BetType.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }
    }
}
