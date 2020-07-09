using System;
using System.Collections.Generic;

namespace HollywoodBets.Models.Model
{
    public partial class Event
    {
        public int EventId { get; set; }
        public int TournamentId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }

        public virtual Tournament Tournament { get; set; }
    }
}
