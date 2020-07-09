using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models.Custom_Models
{
    public class MarketOdds
    {
        [Key]
        public int OddsId { get; set; }
        public int EventId { get; set; }
        public decimal Odds { get; set; }
        public int BetTypeId { get; set;  }
        public int MarketId { get; set; }
        public string MarketName { get; set; }

    }
}
