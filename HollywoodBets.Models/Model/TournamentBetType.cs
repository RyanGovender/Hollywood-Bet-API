using System;
using System.Collections.Generic;

namespace HollywoodBets.Models.Model
{
    public partial class TournamentBetType
    {
        public TournamentBetType()
        {
            AllowedTournamentBets = new HashSet<AllowedTournamentBets>();
        }

        public int TournamentBetTypeId { get; set; }
        public int TournamentId { get; set; }
        public int BetTypeId { get; set; }

        public virtual Tournament Tournament { get; set; }
        public virtual ICollection<AllowedTournamentBets> AllowedTournamentBets { get; set; }
    }
}
