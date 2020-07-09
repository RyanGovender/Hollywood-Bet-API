using System;
using System.Collections.Generic;

namespace HollywoodBets.Models.Model
{
    public partial class MarketBetType
    {
        public int MarketBetTypeId { get; set; }
        public int MarketId { get; set; }
        public int BetTypeId { get; set; }

        public virtual BetType BetType { get; set; }
        public virtual Market Market { get; set; }
    }
}
