
using HollywoodBets.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Interface
{
   public interface IEvent : IRepository<Event>
    {
        IQueryable<Event> GetAllEventsForTournament(int?tournamentId);
    }
}
