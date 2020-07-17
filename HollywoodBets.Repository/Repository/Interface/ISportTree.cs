
using HollywoodBets.Models.Custom_Models;
using HollywoodBets.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Interface
{
    public interface ISportTree :IRepository<SportTree>
    {
        bool AddSportCountryMapping(SportCountry sportCountry);
        IQueryable<SportCountryViewModel> GetAllSportCountries();
        bool DeteleSportCountry(int? id);
        bool UpdateSportCountry(SportCountry sportCountry);
    }
}
