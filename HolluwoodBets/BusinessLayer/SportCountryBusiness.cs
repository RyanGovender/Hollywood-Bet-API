using HollywoodBets.DAL;
using HollywoodBets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.BusinessLayer
{
    public class SportCountryBusiness
    {
        public static IEnumerable<Country> GetSportCountries(int?id)
        {
            var sportFromCountry = Data.GetSportCountry().Where(x => x.SportId == id);
            var matched = from country in Data.GetCountries()
                          where sportFromCountry.Any(x => x.CountryId == country.countryId)
                          select country;
            return CheckIfTournamnetIsActive(matched);     
        }

        private static IEnumerable<Country> CheckIfTournamnetIsActive(IEnumerable<Country> countries)
        {
            var _country = from country in countries
                           where Data.GetSportTournaments().Any(events => events.CountryId == country.countryId)
                           select country;
            return _country;
        }
        public static IEnumerable<Tournament> GetTournamentsBasedOnCountry(int?sportid,int?countryId)
        {
            var tournamentsBasedOnSportAndCountry = Data.GetSportTournaments().Where(x => x.CountryId == countryId && x.SportId == sportid);
            var tournamentCountries = from tournament in Data.GetAllTournament()
                                      where tournamentsBasedOnSportAndCountry.Any(events => events.TournamentId == tournament.TournamentId)
                                      select tournament;
            return tournamentCountries;
        }

        public static IEnumerable<Event> GetAllEvents(int?tournamentId)
        {
            var getEventsBasedOnTournament = from events in Data.GetAllEvents()
                                             where events.TournamentID == tournamentId
                                             select events;
            return getEventsBasedOnTournament;
        }
    }
}
