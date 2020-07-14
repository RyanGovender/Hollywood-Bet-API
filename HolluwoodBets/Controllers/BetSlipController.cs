using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.Models.Custom_Models;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using log4net.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HollywoodBets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class BetSlipController : ControllerBase
    {
        private IBetSlip _betSlip;
        private ILogger<BetSlipController> _logger;
        public BetSlipController(IBetSlip betSlip,ILogger<BetSlipController> logger)
        {
            _betSlip = betSlip;
            _logger = logger;
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] BetSlipViewModel betSlip)
        {
            //var x =_betSlip.Add(betSlip);
            //return StatusCode(200, StatusCodes.ReturnStatusObject("successful"));
            try
            {
                var result = _betSlip.Add(betSlip);
                if (result)
                {
                    _logger.LogInformation("Bet Slip successfully created.");
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Bet Successfully Placed."));
                }
                else
                {
                    _logger.LogError("Bet slip was not created.");
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Unsuccessful."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Creating bet slip has failed. Error - {0}",e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Failed."));
            }
        }
    }
}