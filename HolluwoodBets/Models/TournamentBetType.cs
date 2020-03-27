using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models
{
    public class TournamentBetType
    {
        public int TournamentBetTypeId { get; set; }
        public int TournamentId { get; set; }
        public List<int> AllowedBetTypes { get; set; }

        public TournamentBetType(int tournamentBetTypeId,int tournamentId,List<int> allowedBetType)
        {
            TournamentBetTypeId = tournamentBetTypeId;
            TournamentId = tournamentId;
            AllowedBetTypes = allowedBetType;
        }
    }
}
