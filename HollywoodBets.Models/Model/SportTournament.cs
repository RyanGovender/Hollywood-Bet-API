using System;
using System.Collections.Generic;

namespace HollywoodBets.Models.Model
{
    public partial class SportTournament
    {
        public int SportTournamentId { get; set; }
        public int SportId { get; set; }
        public int TournamentId { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual SportTree Sport { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
