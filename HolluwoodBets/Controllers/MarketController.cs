using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using log4net;
using log4net.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HollywoodBets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class MarketController : Controller
    {
        private IMarket _marketRepository;
        private readonly ILogger<MarketController> _logger;
        public MarketController(IMarket marketRepository, ILogger<MarketController>logger)
        {
            _logger = logger;
            _marketRepository = marketRepository;
        }

        [Route("GetMarkets")]
        public IActionResult GetMarkets(int? betTypeId)
        {
            try
            {
                if (!betTypeId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("Getting markets failed. No parameter provided."));

                var result = _marketRepository.GetMarketsForBetType(betTypeId);

                if(result.Any())
                {
                    _logger.LogInformation("Get all markets for bet type Id :{0} successful", betTypeId);
                    return Ok(result);
                }
                else
                {
                    _logger.LogInformation("Get all markets for bet type Id :{0} has no items.", betTypeId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No markets found."));
                }
            }
            catch(Exception e)
            {
                _logger.LogError("Get all markets for bet type Id :{0} has failed. : Error - {1}", betTypeId,e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Getting markets failed"));
            }
        }
    }
}