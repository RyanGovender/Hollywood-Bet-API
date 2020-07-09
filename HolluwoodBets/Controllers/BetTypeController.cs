using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IQueryable<BetType> GetBetTypes(int? tournamentId)
        {
            _logger.LogInformation("Bet types for tournament Id {0} accessed.",tournamentId);
            return _betTypeRepository.GetBetTypesForTournament(tournamentId);
        }
    }
}