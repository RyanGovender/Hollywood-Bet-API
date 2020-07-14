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
    public class BetTypeRepository :IBetType
    {
        public bool Add(BetType item)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    item.BetTypeName
                };

                var result = connection.Execute("sp_AddBetType", parameters, commandType: CommandType.StoredProcedure);

                return result < 0;
            }
        }

        public bool AddTournamentBetTypes(TournamentBetType tournamentBetType)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new {
                tournamentBetType.TournamentId,
                tournamentBetType.BetTypeId
                };

                var result = connection.Execute("sp_AddTournamentBetType", parameters, commandType: CommandType.StoredProcedure);
                return result < 0;
            }
        }

        public bool Delete(int? id)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { betTypeID = id };
                var affectedRows = connection.Execute("sp_DeleteBetType", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows < 0;
            }
        }

        public BetType Find(int? id)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    Id = id
                };
                var result = connection.Query<BetType>("sp_GetABetType", parameters, commandType: CommandType.StoredProcedure);
                return result.Any() ? result.FirstOrDefault() : null;
            }
        }

        public IQueryable<BetType> GetAll()
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                return connection.Query<BetType>("sp_GetAllBetTypes", commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }

        public IQueryable<BetType> GetBetTypesForTournament(int? tournamentId)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new {tournamentId};
                return connection.Query<BetType>("GetBetTypesForTournament",parameters,commandType:CommandType.StoredProcedure).AsQueryable();
            }
           
        }

        public bool Update(BetType item)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    item.BetTypeId,
                    item.BetTypeName
                };
                var affectedRows = connection.Execute("sp_UpdateBetType", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows < 0;
            }
        }
    }
}
