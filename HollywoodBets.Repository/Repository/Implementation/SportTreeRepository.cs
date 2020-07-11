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

namespace HollywoodBets.Repository.Repository.Implementation
{
    public class SportTreeRepository : ISportTree , ISqlRun<SportTree>
    {
        private IDb _dbService;
      

        public SportTreeRepository(IDb dBContext)
        {
            _dbService = dBContext;
          
        }

        public IQueryable<SportTree> GetAll()
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var result = connection.Query<SportTree>("EXECUTE dbo.GetAllSports ").AsQueryable();
                return result;
            }
        }

        public bool Create(SportTree sportTree)
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

        public bool Update(int?id,SportTree sportTree)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                     Id = id,
                     sportTree.SportName,
                     sportTree.LogoUrl
                };

                var affectedRows = connection.Execute("UPDATE SportTree SET " +
                    "SportName=@SportName," +
                    "LogoUrl=@LogoUrl " +
                    "WHERE SportId =@Id"
                    ,parameters);
                return affectedRows > 0;
            }
        }

        public bool Delete(int?id)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { Id = id };
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

        public IQueryable<SportTree> RunSql(string sqlFormat)
        {
            return _dbService.dBContext().SportTree.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }


    }
}
