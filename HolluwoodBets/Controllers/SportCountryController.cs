using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.BusinessLayer;
using HollywoodBets.DAL;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
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
        public IActionResult Get(int? sportId) //https://localhost:44330/api/sportcountry?sportId=5
        {
            try
            {
                if (!sportId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("SportId Paramter has no value."));
                var results = _countryRepository.GetCountryForSport(sportId);

                if(results.Any())
                {
                    _logger.LogInformation("Get countries for sport id : {0} successful.", sportId);
                    return Ok(results);
                }
                else
                {
                    _logger.LogInformation("Get countries for sport id : {0} has no items", sportId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No items found."));
                }
            }
            catch(Exception e)
            {
                _logger.LogInformation("Get countries for sport id : {0}.  Error - {1}", sportId,e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Failed to retrieve items."));
            }
            
           
        }

        [Route("GetCountryBasedOnTournament")]
        public IActionResult GetCountryBasedOnTournament(int?tournamentId)
        {
            try
            {
                if (!tournamentId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("tournamentId Paramter has no value."));
                var results = _countryRepository.GetCountryBasedOnTournament(tournamentId);

                if (results!=null)
                {
                    _logger.LogInformation("Get countries for sport id : {0} successful.", tournamentId);
                    return Ok(results);
                }
                else
                {
                    _logger.LogInformation("Get countries for sport id : {0} has no items", tournamentId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No items found."));
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation("Get countries for sport id : {0}.  Error - {1}", tournamentId, e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Failed to retrieve items."));
            }
        }

    }
}