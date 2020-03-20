using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models
{
    public class Country
    {
        public int countryId { get; set; }
        public string countryName { get; set; }
        public string iconCode { get; set; }

        public Country (int id, string countryName, string iconCode)
        {
            countryId = id;
            this.countryName = countryName;
            this.iconCode = iconCode;
        }
    }
}
