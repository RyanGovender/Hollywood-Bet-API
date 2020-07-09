using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models.Model
{
    public class BetSlip
    {
        [Key]
        public int id { get; set; }
        public string typeOfEvent { get; set; }
        public Event @event { get; set; }
        public string punterBetSelection { get; set; }
        public double selctionOdds { get; set; }
        public string relatedGamesMessage { get; set; }
        public int warning { get; set; }
        public double stake { get; set; }
        public double payout { get; set; }
    }
}
