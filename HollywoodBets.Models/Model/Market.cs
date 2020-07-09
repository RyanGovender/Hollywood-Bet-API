using System;
using System.Collections.Generic;

namespace HollywoodBets.Models.Model
{
    public partial class Market
    {
        public Market()
        {
            AllowedTournamentBets = new HashSet<AllowedTournamentBets>();
            MarketBetType = new HashSet<MarketBetType>();
        }

        public int MarketId { get; set; }
        public string MarketName { get; set; }
        public decimal Odds { get; set; }

        public virtual ICollection<AllowedTournamentBets> AllowedTournamentBets { get; set; }
        public virtual ICollection<MarketBetType> MarketBetType { get; set; }
    }
}
