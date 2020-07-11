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
    public class TournamentsController : Controller
    {
        private ITournament _tournamentRepository;
        private readonly ILogger<TournamentsController> _logger;
        public TournamentsController(ITournament tournamentRepository,ILogger<TournamentsController> logger)
        {
            _tournamentRepository = tournamentRepository;
            _logger = logger;
        }
       
        //https://localhost:44330/api/sportcountry/?sportId={sportId}&countryId={countryId}
        [HttpGet]
        public IActionResult Get(int? sportId,int?countryId)
        {
            try
            {
                if (!sportId.HasValue && !countryId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("No parameters provided."));
                var result = _tournamentRepository.GetAllTournamentsForSportBasedOnCountry(sportId, countryId);

                if(result.Any())
                {
                    _logger.LogInformation("Get tournaments for sport id : {0} and countryId : {1} successful.", sportId,countryId);
                    return Ok(result);
                }
                else
                {
                    _logger.LogInformation("No items for tournaments for sport id : {0} and countryId : {1}.", sportId, countryId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No items found"));
                }
            }
            catch(Exception e)
            {
                _logger.LogError("Failed to get items for tournaments for sport id : {0} and countryId : {1}. Error - {2}", sportId, countryId,e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Failed to recivece items."));
            }

        }

        [Route("GetTournament")]
        public IActionResult GetTournament(int? tournamentId)
        {

            try
            {
                if (!tournamentId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("No parameters provided."));
                var result = _tournamentRepository.GetTournament(tournamentId);

                if (result!=null)
                {
                    _logger.LogInformation("Get tournaments for tournamentId {0} successful.", tournamentId);
                    return Ok(result);
                }
                else
                {
                    _logger.LogInformation("No items for tournaments  for tournamentId {0}.", tournamentId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No items found"));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to get items for tournaments  for tournamentId {0}. Error - {1}", tournamentId, e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Failed to recivece items."));
            }
        }

    }
}