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
    public class EventRepository : IEvent, ISqlRun<Event>
    {
        private IDb _dbService;
        public EventRepository(IDb dbService)
        {
            _dbService = dbService;
        }

        public TestTable Create(TestTable testTable)
        {
            testTable = new TestTable();
            testTable.TestID = 3;
            testTable.TestStuff = "sckiasbas dsaj dkas";
            testTable.TestData = "saidas djas djas ";
            _dbService.dBContext().TestTables.FromSqlInterpolated($"EXECUTE dbo.AddToTest");
            return testTable;
        }

        public IQueryable<Event> GetAllEventsForTournament(int? tournamentId)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { tournamentId };
                return connection.Query<Event>("GetAllEventsForTournament", parameters, commandType:CommandType.StoredProcedure).AsQueryable();
            }
        }

        public IQueryable<Event> RunSql(string sqlFormat)
        {
            return _dbService.dBContext().Event.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }
      
    }
}
