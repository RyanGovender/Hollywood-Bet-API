using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.BusinessLayer;
using HollywoodBets.Models;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodBets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : Controller
    {
        //https://localhost:44330/api/sportcountry/?sportId={sportId}&countryId={countryId}
        [HttpGet]
        public IEnumerable<Tournament> Get(int? sportId,int?countryId)
        {
            return SportCountryBusiness.GetTournamentsBasedOnCountry(sportId, countryId);
           
        }
    }
}