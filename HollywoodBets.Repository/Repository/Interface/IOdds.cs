
using HollywoodBets.Models.Custom_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Interface
{
    public interface IOdds
    {
        IQueryable<MarketOdds> GetMarketOdds(int?tournamentId);
    }
}
