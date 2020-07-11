using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using log4net.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace HollywoodBets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class BetTypeController : Controller
    {
        private readonly ILogger<BetTypeController> _logger;
        private IBetType _betTypeRepository;
        public BetTypeController(IBetType betTypeRepository, ILogger<BetTypeController> logger)
        {
            _betTypeRepository = betTypeRepository;
            _logger = logger;
        }

        [Route("GetBetTypes")]
        public IActionResult GetBetTypes(int? tournamentId)
        {
            try
            {
                if (!tournamentId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("Retriving bet types has failed."));
                var result = _betTypeRepository.GetBetTypesForTournament(tournamentId);

                if (result.Any())
                {
                    _logger.LogInformation("Bet types for tournament Id {0} has been successfully executed.", tournamentId);
                    return Ok(result);
                }
                else
                {
                    _logger.LogInformation("Bet types for tournament Id {0} has failed.", tournamentId);
                    return StatusCode(400,StatusCodes.ReturnStatusObject("Retriving bet types has failed."));
                }
            }
            catch(Exception e)
            {
                _logger.LogInformation("Bet types for tournament Id {0} has failed. Error : {1}", tournamentId,e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Retriving bet types has failed."));
            }
            //_logger.LogInformation("Bet types for tournament Id {0} accessed.",tournamentId);
            //return _betTypeRepository.GetBetTypesForTournament(tournamentId);
        }
    }
}