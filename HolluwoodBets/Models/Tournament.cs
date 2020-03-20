using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }

        public Tournament(int id,string name)
        {
            TournamentId = id;
            TournamentName = name;
        }
    }
}
