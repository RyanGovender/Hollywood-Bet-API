using HollywoodBets.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Interface
{
    public interface IUnitOfWork
    {
        IBetType BetTypeRepository { get; set;}
        ICountry CountryRepository { get; set; }
        IEvent EventRepository { get; set; }
        IMarket MarketRepository { get; set; }
        IOdds OddsRepository { get; set; }
        ISportTree SportTreeRepository { get; set; }
        ITournament TournamentRepository { get; set; }
        IBetSlip BetSlip { get; set; }
    }
}
