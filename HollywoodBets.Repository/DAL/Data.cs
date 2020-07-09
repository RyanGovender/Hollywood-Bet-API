


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.DAL
{
    public class Data
    {
        //    public static List<SportTree> Sports = GetAllSports();
        //    public static List<Country> Country = null;

        //    public static List<SportTree> GetAllSports()
        //    {

        //        return Sports = new List<SportTree>
        //        {
        //           new SportTree(1, "Betgames Africa", "https://new.hollywoodbets.net/assets/images/icons/Betgames.svg"),
        //            new SportTree(2, "Live In-Play", "https://new.hollywoodbets.net/assets/images/icons/live-in-play.svg"),
        //            new SportTree(3, "Sport Exotics", "https://new.hollywoodbets.net/assets/images/icons/sport-exotics.svg"),
        //            new SportTree(4, "Horse Racing", "https://new.hollywoodbets.net/assets/images/icons/horse-racing.svg"),
        //            new SportTree(5, "Soccer", "https://new.hollywoodbets.net/assets/images/icons/soccer.svg"),
        //            new SportTree(6, "Lucky Numbers", "https://new.hollywoodbets.net/assets/images/icons/lucky-numbers.svg"),
        //            new SportTree(7, "Rugby", "https://new.hollywoodbets.net/assets/images/icons/rugby.svg"),
        //            new SportTree(8, "Cricket", "https://new.hollywoodbets.net/assets/images/icons/cricket.svg"),
        //            new SportTree(9, "Golf", "https://new.hollywoodbets.net/assets/images/icons/golf.svg"),
        //            new SportTree(10, "Aussie Rules", "https://new.hollywoodbets.net/assets/images/icons/aussie-rules.svg"),
        //            new SportTree(11, "Bandy", "https://new.hollywoodbets.net/assets/images/icons/bandy.svg"),
        //            new SportTree(12, "BasketBall", "https://new.hollywoodbets.net/assets/images/icons/basketball.svg"),
        //            new SportTree(13, "Bowls", "https://new.hollywoodbets.net/assets/images/icons/bowls.svg"),
        //            new SportTree(14, "Boxing", "https://new.hollywoodbets.net/assets/images/icons/boxing.svg"),
        //            new SportTree(15, "Darts", "https://new.hollywoodbets.net/assets/images/icons/darts.svg"),
        //            new SportTree(16, "Futsal", "https://new.hollywoodbets.net/assets/images/icons/futsal.svg"),
        //            new SportTree(17, "Ice Hockey", "https://new.hollywoodbets.net/assets/images/icons/ice-hockey.svg"),
        //            new SportTree(18, "MMA", "https://new.hollywoodbets.net/assets/images/icons/mma.svg"),
        //            new SportTree(19, "Motorsport", "https://new.hollywoodbets.net/assets/images/icons/motorsport.svg"),
        //            new SportTree(20, "Table Tennis", "https://new.hollywoodbets.net/assets/images/icons/sport-exotics.svg"),
        //            new SportTree(21, "Vollyball", "https://new.hollywoodbets.net/assets/images/icons/volleyball.svg")
        //        };

        //    }

        //    public static List<Country> GetCountries()
        //    {
        //        return Country = new List<Country>
        //        {
        //            new Country(1,"England","GB"),
        //            new Country(2,"Spain","ES"),
        //            new Country(3,"Brazil","BR"),
        //            new Country(4,"Germany","DE"),
        //            new Country(5,"India","IN")
        //        };
        //    }

        //    public static List<SportCountry> GetSportCountry()
        //    {
        //        var list = new List<SportCountry>
        //        {
        //            new SportCountry(5,1),
        //            new SportCountry(5,2),
        //            new SportCountry(5,3),
        //            new SportCountry(5,4),
        //            new SportCountry(8,5),
        //            new SportCountry(8,3),
        //        };

        //        return list;
        //    }

        //    public static List<Tournament> GetAllTournament()
        //    {
        //        return new List<Tournament>
        //        {
        //            new Tournament(1,"Premier League"),
        //            new Tournament(2,"La Liga"),
        //            new Tournament(3,"Serie A"),
        //            new Tournament(4,"Bundesliga"),
        //            new Tournament(5,"Serie A"),
        //            new Tournament(6,"IPL"),
        //            new Tournament(7,"English Championship"),
        //            new Tournament(8,"Big Bash")
        //        };
        //    }

        //    public static List<SportTournament> GetSportTournaments() // sport , tournament, country
        //    {
        //        return new List<SportTournament>
        //        {
        //            new SportTournament(5,1,1),
        //            new SportTournament(5,2,2),
        //            new SportTournament(5,4,4),
        //            new SportTournament(5,5,3),
        //            new SportTournament(8,6,5),
        //            new SportTournament(8,8,3),
        //            new SportTournament(5,7,1)
        //        };
        //    }

        //    public static List<Event> GetAllEvents()
        //    {
        //        return new List<Event>
        //        {
        //           new Event(1,1,"Manchester United vs Manchester City",DateTime.Now.Date),
        //           new Event(1,2,"Newcastle vs Everton",DateTime.Now.Date),
        //           new Event(2,3,"Real Mardrid vs FC Barcelona",DateTime.Now.Date),
        //           new Event(6,4,"Chennai Super Kings vs Royal Challengers Bangalore ",DateTime.Now.Date)
        //        };

        //    }

        //    public static List<BetTypes> AllBetTypes()
        //    {
        //        return new List<BetTypes>
        //        {
        //            new BetTypes(1,"Full Time"),
        //            new BetTypes(2,"Double Chance"),
        //            new BetTypes(3,"Both Teams To Score"),
        //            new BetTypes(4,"Totals"),
        //            new BetTypes(5,"Half Time"),
        //            new BetTypes(6,"Winner")
        //        };
        //    }

        //    public static List<TournamentBetType> TournamentBetTypes()
        //    {
        //        return new List<TournamentBetType>
        //        {
        //            new TournamentBetType(1,1,new List<int>{
        //           1,2,3,4,5})
        //            ,new TournamentBetType(3,2,new List<int>{ 1,2,3,5})
        //           ,new TournamentBetType(2,6,new List<int>{6})
        //        };
        //    }

        //    public static List<Market> AllMarkets()
        //    {
        //        return new List<Market>
        //        {
        //            new Market(1,"Home"),
        //            new Market(2,"Draw"),
        //            new Market(3,"Away"),
        //            new Market(4,"Yes"),
        //            new Market(5,"No"),
        //            new Market(6,"Under 2.5"),
        //            new Market(7,"Over 2.5"),
        //            new Market(8,"Home + Away"),
        //            new Market(9,"Home + Draw"),
        //            new Market(10,"Away + Draw")
        //        };
        //    }

        //    public static List<MarketBetType> MarketForBetTypes()//market && bettype 
        //    {
        //        return new List<MarketBetType>
        //        {
        //            new MarketBetType(1,1),
        //            new MarketBetType(2,1),
        //            new MarketBetType(3,1),
        //            new MarketBetType(4,3),
        //            new MarketBetType(5,3),
        //            new MarketBetType(1,6),
        //            new MarketBetType(3,6),
        //            new MarketBetType(6,4),
        //            new MarketBetType(7,4),
        //            new MarketBetType(8,2),
        //            new MarketBetType(9,2),
        //            new MarketBetType(10,2),
        //            new MarketBetType(1,5),
        //            new MarketBetType(2,5),
        //            new MarketBetType(3,5)
        //        };
        //    }
        //}
    }
}
