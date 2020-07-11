using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.Models.Custom_Models;
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
    public class OddsController : Controller
    {
        private IOdds _oddsRepository;
        private readonly ILogger<OddsController> _logger;
        public OddsController(IOdds oddsRepository, ILogger<OddsController> logger)
        {
            _logger = logger;
            _oddsRepository = oddsRepository;
        }

        [HttpGet]
        public IActionResult Get(int?tournamentId)
        {
            try
            {
                if (!tournamentId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("No paramter provided for Market Odds"));

                var result = _oddsRepository.GetMarketOdds(tournamentId);
                if(result.Any())
                {
                    _logger.LogInformation("Get odds for markets for tournament Id : {0} successful", tournamentId);
                    return Ok(result);
                }
                else
                {
                    _logger.LogInformation("Get odds for markets for tournament Id : {0} has no items.", tournamentId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Market odds contains no items."));
                }
            }
            catch(Exception e)
            {
                _logger.LogInformation("Get odds for markets for tournament Id : {0}. Error - {1}", tournamentId,e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Markets odds has failed"));
            }
        }
    }
}