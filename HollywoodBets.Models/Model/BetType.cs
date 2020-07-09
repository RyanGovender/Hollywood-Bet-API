using System;
using System.Collections.Generic;

namespace HollywoodBets.Models.Model
{
    public partial class BetType
    {
        public BetType()
        {
            MarketBetType = new HashSet<MarketBetType>();
        }

        public int BetTypeId { get; set; }
        public string BetTypeName { get; set; }

        public virtual ICollection<MarketBetType> MarketBetType { get; set; }
    }
}
