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
    public class MarketRepository : IMarket
    {
        public bool Add(Market item)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    item.MarketName
                };
                var result = connection.Execute("sp_AddMarket", parameters, commandType: CommandType.StoredProcedure);
                return result < 0;
            }
        }

        public bool Delete(int? id)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { marketID = id };
                var affectedRows = connection.Execute("sp_DeleteMarket", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows <0;
            }
        }

        public Market Find(int? id)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    Id = id
                };
                var result = connection.Query<Market>("sp_FindAMarket", parameters, commandType: CommandType.StoredProcedure);
                return result.Any() ? result.FirstOrDefault() : null;
            }
        }

        public IQueryable<Market> GetAll()
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                return connection.Query<Market>("sp_GetAllMarkets", commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }

        public IQueryable<Market> GetMarketsForBetType(int? betTypeId)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { betTypeId};
                return connection.Query<Market>("GetMarketsForBetType",parameters,commandType:CommandType.StoredProcedure).AsQueryable();
            }
        }

        public bool Update(Market item)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    item.MarketId,
                    item.MarketName
                };
                var affectedRows = connection.Execute("sp_UpdateMarket", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows < 0;
            }
        }
    }
}
