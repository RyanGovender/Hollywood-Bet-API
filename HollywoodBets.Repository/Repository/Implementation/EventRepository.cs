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
            return RunSql($"EXECUTE dbo.GetAllEventsForTournament {tournamentId}");
        }

        public IQueryable<Event> RunSql(string sqlFormat)
        {
            return _dbService.dBContext().Event.FromSqlRaw($"{sqlFormat}").AsQueryable();
        }
      
    }
}
