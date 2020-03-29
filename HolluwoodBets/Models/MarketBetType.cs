using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models
{
    public class MarketBetType
    {
        public int MarketId { get; set; }
        public int BetTypeId { get; set; }
        public MarketBetType (int marketId,int betTypeId)
        {
            MarketId = marketId;
            BetTypeId = betTypeId;
        }
    }
}
