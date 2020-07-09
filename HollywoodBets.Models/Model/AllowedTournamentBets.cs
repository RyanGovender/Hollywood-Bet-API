using System;
using System.Collections.Generic;

namespace HollywoodBets.Models.Model
{
    public partial class AllowedTournamentBets
    {
        public int AllowedBetId { get; set; }
        public int TournamentBetTypeId { get; set; }
        public int MarketId { get; set; }

        public virtual Market Market { get; set; }
        public virtual TournamentBetType TournamentBetType { get; set; }
    }
}
