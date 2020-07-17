
using HollywoodBets.Models.Custom_Models;
using HollywoodBets.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Interface
{
    public interface ITournament :IRepository<Tournament>
    {
        Tournament GetTournament(int?tournamentId);
        IQueryable<Tournament> GetAllTournamentsForSportBasedOnCountry(int?sportId,int?countryId);
        bool AddSportTournamentCountry(SportTournament sportTournament);
        IQueryable<SportCountryTournamentVM> GetAllSportTournmentCountries();
    }
}
