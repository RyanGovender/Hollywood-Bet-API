using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models
{
    public class Event
    {
        public int TournamentID { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    

        public Event(int tournamentId,int eventId, string eventName,DateTime eventDate)
        {
            TournamentID = tournamentId;
            EventID = eventId;
            EventName = eventName;
            EventDate = eventDate;
          
        }
    }
}
