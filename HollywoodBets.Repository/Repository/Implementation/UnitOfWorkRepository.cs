using HollywoodBets.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Implementation
{ 
    public class UnitOfWorkRepository : IUnitOfWork
    {
        public IBetType BetTypeRepository { get; set; }
        public ICountry CountryRepository { get; set; }
        public IEvent EventRepository { get; set; }
        public IMarket MarketRepository { get; set; }
        public ISportTree SportTreeRepository { get; set; }
        public ITournament TournamentRepository { get; set; }
        public IBetSlip BetSlip { get; set; }
        public IOdds OddsRepository { get; set; }

        public UnitOfWorkRepository(IBetType betType,
                                    ICountry country,
                                    IEvent @event, 
                                    IMarket market, 
                                    ISportTree sportTree,
                                    ITournament tournament,
                                    IBetSlip betSlip,
                                    IOdds odds
                                   )
        {
            BetTypeRepository = betType;
            CountryRepository = country;
            EventRepository = @event;
            MarketRepository = market;
            SportTreeRepository = sportTree;
            TournamentRepository = tournament;
            BetSlip = betSlip;
            OddsRepository = odds;
        }

    }
}
