using System;
using System.Collections.Generic;

namespace HollywoodBets.Models.Model
{
    public partial class Country
    {
        public Country()
        {
            SportCountry = new HashSet<SportCountry>();
            SportTournament = new HashSet<SportTournament>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string IconCode { get; set; }

        public virtual ICollection<SportCountry> SportCountry { get; set; }
        public virtual ICollection<SportTournament> SportTournament { get; set; }
    }
}
