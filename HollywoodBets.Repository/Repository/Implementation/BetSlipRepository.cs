using Dapper;
using HollywoodBets.DAL;
using HollywoodBets.Models.Custom_Models;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Implementation
{
    public class BetSlipRepository : IBetSlip
    {
        private IDb _dbService;
        private  int _lastBetID = 0;

        public BetSlipRepository(IDb dbService)
        {
            _dbService = dbService;
        }
        public bool Add(BetSlipViewModel betSlip)
        {
            var item = betSlip.betSlips;
            using(var connection = DatabaseService.SqlConnection())
            {
                var betSlipParameters = new
                {
                    betSlip.PunterBetSlip.Payout,
                    betSlip.PunterBetSlip.Stake,
                    betSlip.PunterBetSlip.NumberOfLegs,
                    betSlip.PunterBetSlip.AccountNumber,
                    dateTaken = betSlip.PunterBetSlip.DateTake = DateTime.Now
                };

                var result = connection.Execute("sp_AddToPunterBetSlip", betSlipParameters, commandType: CommandType.StoredProcedure);

                getLastBetIDValue(connection,betSlip.PunterBetSlip);

                for (int i = 0; i < item.Length; i++)
                {
                    Add(item[i]);
                }

                return result<0;
            }
        }

        public bool Add(BetSlip item)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    item.typeOfEvent,
                    eventId = item.@event.EventId,
                    item.punterBetSelection,
                    item.selctionOdds,
                    punterBetSlipID = _lastBetID
                };
                var affectedRows = connection.Execute("AddToBetSlip", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }

        private void getLastBetIDValue(SqlConnection connection, PunterBetSlip punterBetSlip)
        {
            var parameterId = new
            {
              punterBetSlip.AccountNumber
            };

            var getUserLastBet = connection.Query<PunterBetSlip>("sp_GetLastBetSlipID", parameterId, commandType: CommandType.StoredProcedure);
            if (getUserLastBet.Any()) _lastBetID = getUserLastBet.ElementAt(0).PunterBetSlipID;
        }

        public bool Delete(int?id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BetSlip> GetAll()
        {
            throw new NotImplementedException();
        }

        public BetSlip GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BetSlip item)
        {
            throw new NotImplementedException();
        }

        bool IRepository<BetSlip>.Update(BetSlip item)
        {
            throw new NotImplementedException();
        }

        public BetSlip Find(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
