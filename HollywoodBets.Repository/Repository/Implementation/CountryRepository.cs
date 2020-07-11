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
    public class CountryRepository : ICountry, ISqlRun<Country>
    {
        private IDb _dBService;
        public CountryRepository(IDb dbService)
        {
            _dBService = dbService;  
        }

        public Country GetCountryBasedOnTournament(int? tournamentId)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { tournamentId};
                var result = connection.Query<Country>("GetCountryBasedOnTournament", parameters, commandType: CommandType.StoredProcedure).First();
                return result != null ? result : null;
            }
        }

        public IQueryable<Country> GetCountryForSport(int? sportId)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameter = new { sportId };
                return connection.Query<Country>("GetSportForSelectedCountry", parameter, commandType:CommandType.StoredProcedure).AsQueryable();
            }
        }

        public IQueryable<Country> RunSql(string sqlFormat)
        {
            return _dBService.dBContext().Country.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }
       
    }
}
