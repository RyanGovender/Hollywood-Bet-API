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
    public class CountryRepository : ICountry, ISqlRun<Country>
    {
        private IDb _dBService;
        public CountryRepository(IDb dbService)
        {
            _dBService = dbService;  
        }

        public Country GetCountryBasedOnTournament(int? tournamentId)
        {
            return RunSql($"EXECUTE dbo.GetCountryBasedOnTournament {tournamentId}").AsEnumerable().FirstOrDefault();
        }

        public IQueryable<Country> GetCountryForSport(int? sportId)
        {
            return RunSql($"EXECUTE dbo.GetSportForSelectedCountry {sportId}");
        }

        public IQueryable<Country> RunSql(string sqlFormat)
        {
            return _dBService.dBContext().Country.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }
       
    }
}
