using System;
using System.Collections.Generic;

namespace HollywoodBets.Models.Model
{
    public partial class SportTree
    {
        public SportTree()
        {
            SportCountry = new HashSet<SportCountry>();
            SportTournament = new HashSet<SportTournament>();
        }

        public int SportId { get; set; }
        public string SportName { get; set; }
        public string LogoUrl { get; set; }

        public virtual ICollection<SportCountry> SportCountry { get; set; }
        public virtual ICollection<SportTournament> SportTournament { get; set; }
    }
}
