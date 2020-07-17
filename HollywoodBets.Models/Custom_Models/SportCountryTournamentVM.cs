using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HollywoodBets.Models.Custom_Models
{
   public class SportCountryTournamentVM
    {
        [Key]
        public int SportTournamentId { get; set; }
        public string TournamentName { get; set; }
        public string SportName { get; set; }
        public string CountryName { get; set; }
    }
}
