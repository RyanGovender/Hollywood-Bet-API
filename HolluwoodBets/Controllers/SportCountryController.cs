using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.BusinessLayer;
using HollywoodBets.DAL;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.Repository.Interface;
using log4net.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HollywoodBets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class SportCountryController : Controller
    {

       
        private ICountry _countryRepository;
        private readonly ILogger<SportController> _logger;
        public SportCountryController(ICountry countryRepository,ILogger<SportController> logger)
        {
            _countryRepository = countryRepository;
            _logger = logger;
        }

        [HttpGet]
        public IQueryable<Country> Get(int? sportId) //https://localhost:44330/api/sportcountry?sportId=5
        {
            _logger.LogInformation("Get countries for sport id : {0}",sportId);
            return _countryRepository.GetCountryForSport(sportId);
        }

        [Route("GetCountryBasedOnTournament")]
        public Country GetCountryBasedOnTournament(int?tournamentId)
        {
            return _countryRepository.GetCountryBasedOnTournament(tournamentId);
        }

    }
}