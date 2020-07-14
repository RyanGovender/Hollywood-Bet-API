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
    public class CountryRepository : ICountry
    {
        public bool Add(Country item)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new {
                item.CountryName,
                item.IconCode
                };

                var result = connection.Execute("sp_AddCountry",parameters,commandType:CommandType.StoredProcedure);

                return result < 0;
            }
        }

        public bool Delete(int? id)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { countryId = id };
                var affectedRows = connection.Execute("sp_DeleteCountry", parameters,commandType:CommandType.StoredProcedure);
                return affectedRows < 0;
            }
        }

        public Country Find(int? id)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    Id = id
                };
                var result = connection.Query<Country>("sp_FindCountry", parameters,commandType:CommandType.StoredProcedure);
                return result.Any() ? result.FirstOrDefault() : null;
            }
        }

        public IQueryable<Country> GetAll()
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                return connection.Query<Country>("sp_GetAllCountries",commandType:CommandType.StoredProcedure).AsQueryable();
            }
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
    
        public bool Update(Country item)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    item.CountryId,
                    item.CountryName,
                    item.IconCode
                };
                var affectedRows = connection.Execute("sp_UpdateCountry",parameters,commandType:CommandType.StoredProcedure);
                return affectedRows < 0;
            }
        }
    }
}
