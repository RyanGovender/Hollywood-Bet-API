using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HollywoodBets.Models.Custom_Models
{
    public class TournamentBetTypeVM
    {
        [Key]
        public int TournamentBetTypeId { get; set; }
        public string TournamentName { get; set; }
        public string BetTypeName { get; set; }
    }
}
