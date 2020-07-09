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
    public class BetSlipRepository : IBetSlip
    {
        private IDb _dbService;

        public BetSlipRepository(IDb dbService)
        {
            _dbService = dbService;
        }
        public void Add(BetSlip item)
        {
            item = new BetSlip();
            item.id = 123;
            item.@event = new Event { EventId = 1, EventName = " Hello", EventDate = DateTime.Now, TournamentId = 1 };
            item.payout = 123;
            item.punterBetSelection = "dfa";
            item.relatedGamesMessage = "fskf df afd ";
            item.selctionOdds = 12.12;
            item.typeOfEvent = "soccer";
            item.warning = 1;

            _dbService.dBContext().BetSlip.FromSqlInterpolated($"EXECUTE dbo.AddToBetSlip {item.id},{item.typeOfEvent},{item.@event},{item.punterBetSelection},{item.selctionOdds},{item.relatedGamesMessage},{item.warning},{item.stake}");
        }

        public void Delete(int id)
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
    }
}
