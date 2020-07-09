
using HollywoodBets.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.BusinessLayer
{
    public class SportCountryBusiness
   {
    //    public static IEnumerable<Country> GetSportCountries(int?id)
    //    {
    //        var sportFromCountry = Data.GetSportCountry().Where(x => x.SportId == id);
    //        var matched = from country in Data.GetCountries()
    //                      where sportFromCountry.Any(x => x.CountryId == country.countryId)
    //                      select country;
    //        return CheckIfTournamnetIsActive(matched);     
    //    }

    //    private static IEnumerable<Country> CheckIfTournamnetIsActive(IEnumerable<Country> countries)
    //    {
    //        var _country = from country in countries
    //                       where Data.GetSportTournaments().Any(events => events.CountryId == country.countryId)
    //                       select country;
    //        return _country;
    //    }
    //    public static IEnumerable<Tournament> GetTournamentsBasedOnCountry(int?sportid,int?countryId)
    //    {
    //        var tournamentsBasedOnSportAndCountry = Data.GetSportTournaments().Where(x => x.CountryId == countryId && x.SportId == sportid);
    //        var tournamentCountries = from tournament in Data.GetAllTournament()
    //                                  where tournamentsBasedOnSportAndCountry.Any(events => events.TournamentId == tournament.TournamentId)
    //                                  select tournament;
    //        return tournamentCountries;
    //    }

    //    public static IEnumerable<Event> GetAllEvents(int?tournamentId)
    //    {
    //        var getEventsBasedOnTournament = from events in Data.GetAllEvents()
    //                                         where events.TournamentID == tournamentId
    //                                         select events;
    //        return getEventsBasedOnTournament;
    //    }

    //    public static IEnumerable<BetTypes> GetBetTypesForTournament(int?tournamentId)
    //    {
    //        List<BetTypes> _betTypes = new List<BetTypes>();
    //        var getBetTypesBasedOnTournaments = Data.TournamentBetTypes().Where(x => x.TournamentId.Equals(tournamentId)).FirstOrDefault();
    //        if (getBetTypesBasedOnTournaments == null) return null;
    //        for (int i = 0; i < Data.AllBetTypes().Count; i++)
    //        {
    //            for (int x = 0; x < getBetTypesBasedOnTournaments.AllowedBetTypes.Count; x++)
    //            {
    //                if (Data.AllBetTypes().ElementAt(i).BetTypeId == getBetTypesBasedOnTournaments.AllowedBetTypes[x] )
    //                {
    //                    _betTypes.Add(Data.AllBetTypes().ElementAt(i));
    //                }
    //            }
    //        }
    //        return _betTypes;
    //    }

    //    public static Tournament GetTournaments(int?tournamentId)
    //    {
    //        var _selectedTournament = Data.GetAllTournament().Where(x => x.TournamentId == tournamentId).FirstOrDefault();
    //        return _selectedTournament != null ? _selectedTournament : null;
    //    }

    //    public static Country GetCountryBasedOnSelectedTournament(int?tournamentId)
    //    {
    //        int? _getCountryId = Data.GetSportTournaments().Where(x => x.TournamentId == tournamentId).FirstOrDefault().CountryId;
    //        return _getCountryId != null ? GetCountry(_getCountryId) : null;

    //    }

    //    public static Country GetCountry(int?countryId)
    //    {
    //        var _country = Data.GetCountries().Where(country => country.countryId == countryId).FirstOrDefault();
    //        return _country != null ? _country : null;
    //    }

    //    public static IEnumerable<Market> GetBetTypes(int?betTypeId)
    //    {
    //        var _marketForBetTypes = GetMarketForBetType(betTypeId).ToList();
    //        List<Market> _market = new List<Market>();
    //        if (_marketForBetTypes == null) return null;
    //        for (int i = 0; i < _marketForBetTypes.Count; i++)
    //        {
    //            for (int x = 0; x < Data.AllMarkets().Count; x++)
    //            {
    //                var _marketId = Data.AllMarkets().ElementAt(x);
    //                if (_marketForBetTypes[i].MarketId == _marketId.MarketId)
    //                {
    //                    _market.Add(_marketId);
    //                }
    //            }
    //        }
    //        return _market;
    //    }

    //    public static IEnumerable<MarketBetType> GetMarketForBetType(int?betTypeId)
    //    {
    //        return Data.MarketForBetTypes().Where(bettype => bettype.BetTypeId == betTypeId);
    //    }
        
    }
}
