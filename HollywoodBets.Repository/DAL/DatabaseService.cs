
using HollywoodBets.Models.Model;
using HollywoodBets.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.DAL
{
    public class DatabaseService : IDb
    {
        private HollywoodBetsDBContext _dbContext;
        private static readonly string _sqlConnectionString = "Server=(LocalDb)\\MSSQLLocalDB;initial catalog=HollywoodBetsDB;Trusted_Connection=True;";
        public DatabaseService(HollywoodBetsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public HollywoodBetsDBContext dBContext()
        {
            return _dbContext;
        }

        public static SqlConnection SqlConnection()
        {
            var connection = new SqlConnection(_sqlConnectionString);
            return  connection;
        }
    }
}
