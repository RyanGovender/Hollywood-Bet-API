using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models
{
    public class Market
    {
        public int MarketId { get; set; }
        public string MarketName { get; set; }

        public Market(int marketId,string marketName)
        {
            MarketId = marketId;
            MarketName = marketName;
        }
    }
}
