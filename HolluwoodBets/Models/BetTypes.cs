using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models
{
    public class BetTypes
    {
        public int BetTypeId { get; set; }
        public string BetTypeName { get; set; }
        public BetTypes(int betTypeId,string betTypeName)
        {
            BetTypeId = betTypeId;
            BetTypeName = betTypeName;
        }
    }
}
