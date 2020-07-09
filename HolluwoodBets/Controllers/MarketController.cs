using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.Models.Model;
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
        public IQueryable<Market> GetMarkets(int? betTypeId)
        {
            _logger.LogInformation("Get all markets for bet type Id :{0}", betTypeId);
            return _marketRepository.GetMarketsForBetType(betTypeId);
        }
    }
}