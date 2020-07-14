
using HollywoodBets.Models.Custom_Models;
using HollywoodBets.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Interface
{
    public interface IBetSlip : IRepository<BetSlip>
    {
        bool Add(BetSlipViewModel item);
    }
}
