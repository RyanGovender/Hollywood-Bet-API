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
    public class EventRepository : IEvent
    {
        public bool Add(Event item)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    item.TournamentId,
                    item.EventName,
                    item.EventDate
                };

                var result = connection.Execute("sp_AddEvent", parameters, commandType: CommandType.StoredProcedure);

                return result < 0;
            }
        }

        public bool AddOdds(Odds odds)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    odds.MarketBetTypeId,
                    odds.EventId,
                    @oddsValue = Math.Round(odds.OddsValue,2)
                };

                var result = connection.Execute("sp_AddOdds", parameters, commandType: CommandType.StoredProcedure);

                return result < 0;
            }
        }

        public bool Delete(int? id)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { eventID = id };
                var affectedRows = connection.Execute("sp_DeleteAnEvent", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows < 0;
            }
        }

        public Event Find(int? id)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    Id = id
                };
                var result = connection.Query<Event>("sp_FindAnEvent", parameters, commandType: CommandType.StoredProcedure);
                return result.Any() ? result.FirstOrDefault() : null;
            }
        }

        public IQueryable<Event> GetAll()
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                return connection.Query<Event>("sp_GetAllEvents", commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }

        public IQueryable<Event> GetAllEventsForTournament(int? tournamentId)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { tournamentId };
                return connection.Query<Event>("GetAllEventsForTournament", parameters, commandType:CommandType.StoredProcedure).AsQueryable();
            }
        }

        public bool Update(Event item)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    item.EventId,
                    item.TournamentId,
                    item.EventName,
                    item.EventDate
                };
                var affectedRows = connection.Execute("sp_UpdateEvent", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows < 0;
            }
        }
    }
}
