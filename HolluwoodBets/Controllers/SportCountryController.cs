using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.BusinessLayer;
using HollywoodBets.DAL;
using HollywoodBets.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodBets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class SportCountryController : Controller
    {
        //https://localhost:44330/api/sportcountry?id={SportId}

        [HttpGet]
        public IEnumerable<Country> Get(int? sportId)
        {
            return SportCountryBusiness.GetSportCountries(sportId);
        }

    }
}