using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HollywoodBets.Models.Model
{
    public class Odds
    {
        [Key]
        public int OddsId { get; set; }
        public int MarketBetTypeId { get; set; }
        public int EventId { get; set; }
        public float OddsValue { get; set; }
    }
}
