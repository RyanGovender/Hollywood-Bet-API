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
    public class TournamentRepository : ITournament, ISqlRun<Tournament>
    {
        private IDb _dbService;
        public TournamentRepository(IDb dbService)
        {
            _dbService = dbService;
        }
        public IQueryable<Tournament> GetAllTournamentsForSportBasedOnCountry(int? sportId, int? countryId)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { sportId,countryId };
                return connection.Query<Tournament>("GetTournamentBasedOnSportAndCountry",parameters,commandType:CommandType.StoredProcedure).AsQueryable();
            }
        }

        public Tournament GetTournament(int? tournamentId)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { tournamentId };
                var result = connection.Query<Tournament>("GetTournament", parameters, commandType: CommandType.StoredProcedure).First();
                return result != null ? result : null;
            }
        }

        public IQueryable<Tournament> RunSql(string sqlFormat)
        {
            return _dbService.dBContext().Tournament.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }
    }
}
