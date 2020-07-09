using System;
using System.Collections.Generic;

namespace HollywoodBets.Models.Model
{ 
    public partial class Tournament
    {
        public Tournament()
        {
            Event = new HashSet<Event>();
            SportTournament = new HashSet<SportTournament>();
            TournamentBetType = new HashSet<TournamentBetType>();
        }

        public int TournamentId { get; set; }
        public string TournamentName { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<SportTournament> SportTournament { get; set; }
        public virtual ICollection<TournamentBetType> TournamentBetType { get; set; }
    }
}
