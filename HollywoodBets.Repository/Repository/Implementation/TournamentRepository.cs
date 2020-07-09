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
    public class TournamentRepository : ITournament, ISqlRun<Tournament>
    {
        private IDb _dbService;
        public TournamentRepository(IDb dbService)
        {
            _dbService = dbService;
        }
        public IQueryable<Tournament> GetAllTournamentsForSportBasedOnCountry(int? sportId, int? countryId)
        {
            return RunSql($"EXECUTE dbo.GetTournamentBasedOnSportAndCountry {sportId},{countryId}");
        }

        public Tournament GetTournament(int? tournamentId)
        {
            return RunSql($"EXECUTE dbo.GetTournament {tournamentId}").AsEnumerable().FirstOrDefault();
        }

        public IQueryable<Tournament> RunSql(string sqlFormat)
        {
            return _dbService.dBContext().Tournament.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }
    }
}
