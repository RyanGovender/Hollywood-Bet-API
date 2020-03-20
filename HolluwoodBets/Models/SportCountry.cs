using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models
{
    public class SportCountry
    {
        public int SportId { get; set; }
       /// public virtual SportTree SportTree { get; set; }
        public int CountryId { get; set; }
      //  public virtual Country Country { get; set; }

        public SportCountry(int sportId, int countryId)
        {
            SportId = sportId;
            CountryId = countryId;
        }

    }
}
