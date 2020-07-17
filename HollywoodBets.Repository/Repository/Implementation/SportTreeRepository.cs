using HollywoodBets.DAL;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using HollywoodBets.Models.Custom_Models;

namespace HollywoodBets.Repository.Repository.Implementation
{
    public class SportTreeRepository : ISportTree 
    {
        
        public IQueryable<SportTree> GetAll()
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var result = connection.Query<SportTree>("EXECUTE dbo.GetAllSports ").AsQueryable();
                return result;
            }
        }

        public bool Add(SportTree sportTree)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                     sportTree.SportName,
                     sportTree.LogoUrl
                };

             var affectedRows =  connection.Execute("INSERT INTO SportTree" +
                    "(" +
                    "SportName," +
                    "LogoUrl)" +
                    "VALUES" +
                    "(" +
                    "@SportName," +
                    "@LogoUrl)",
                    parameters);

                return affectedRows > 0;
            }
            
        }

        public bool Update(SportTree sportTree)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                     sportTree.SportId,
                     sportTree.SportName,
                     sportTree.LogoUrl
                };

                var affectedRows = connection.Execute("UPDATE SportTree SET " +
                    "SportName=@SportName," +
                    "LogoUrl=@LogoUrl " +
                    "WHERE SportId =@SportId"
                    , parameters);
                return affectedRows > 0;
            }
        }

        public bool Delete(int?id)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { @Id = id };
                var affectedRows =connection.Execute("DELETE SportTree WHERE SportId = @Id",parameters);
                return affectedRows > 0;
            }
        }

        public SportTree Find(int?id)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    Id = id
                };

                var result = connection.Query<SportTree>("Select * FROM SportTree WHERE SportId = @Id", parameters);

                return result.Any() ? result.FirstOrDefault() : null;
            }
        }

        public bool AddSportCountryMapping(SportCountry sportCountry)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    sportCountry.CountryId,
                    sportCountry.SportId
                };

                var result = connection.Execute("sp_SportCountry",parameters,commandType:CommandType.StoredProcedure);
                return result < 0;
            }
        }

        public IQueryable<SportCountryViewModel> GetAllSportCountries()
        {
           using(var connection = DatabaseService.SqlConnection())
            {
                return connection.Query<SportCountryViewModel>("sp_GetSportCountry", commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }

        public bool DeteleSportCountry(int?id)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameter = new { sportCountryId = id };
                return connection.Execute("sp_DeleteSportCountry", parameter, commandType: CommandType.StoredProcedure) < 0;
            }

        }

        public bool UpdateSportCountry(SportCountry sportCountry)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { sportCountry.SportCountryId 
                ,sportCountry.SportId,
                sportCountry.CountryId
                };

                return connection.Execute("sp_UpdateSportCountry", parameters, commandType: CommandType.StoredProcedure) < 0;
            }
        }


    }
}
