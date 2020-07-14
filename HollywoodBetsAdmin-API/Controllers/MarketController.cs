using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HollywoodBetsAdmin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class MarketController : ControllerBase
    {
        private ILogger<MarketController> _logger;
        private IMarket _marketRepository;

        public MarketController(ILogger<MarketController> logger, IMarket marketRepository)
        {
            _logger = logger;
            _marketRepository = marketRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _marketRepository.GetAll();
                if (result.Any())
                {
                    _logger.LogInformation("Successfully recieved Market Data.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("No Market data. Data - {0}", result);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No Market data."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error recieving data. Error - {0}. Data - {1}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error recieving Market data."));
            }
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] Market market)
        {
            try
            {
                if (market == null) return StatusCode(400, StatusCodes.ReturnStatusObject("No items have been provided."));
                var result = _marketRepository.Add(market);
                if (result)
                {
                    _logger.LogInformation("Market Successfully Added");
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Successfully Added."));
                }
                else
                {
                    _logger.LogError("Market has Failed to Add. Market - {0}", market);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Market failed to add."));
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Error Market failed to add . Error - {0} , Data - {1}", e.Message, market);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error Market Failed to Add." + e.Message));
            }
        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Put([FromBody]Market market)
        {
            try
            {
                if (market.Equals(null)) return StatusCode(400, StatusCodes.ReturnStatusObject("The was no data present."));
                var result = _marketRepository.Update(market);

                if (result)
                {
                    _logger.LogInformation("Market ID : {0} successfully updated.", market.MarketId);
                    return StatusCode(200, StatusCodes.ReturnStatusObject($"{market.MarketId} was Successfully Updated."));
                }
                else
                {
                    _logger.LogError("Market ID : {0} was not updated.", market.MarketId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject($"Update was unsuccessful."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("The Market update has failed. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("The update has failed."));
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int? marketId)
        {
            try
            {
                if (!marketId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("No parameter provided."));
                var result = _marketRepository.Delete(marketId);

                if (result)
                {
                    _logger.LogInformation($"ID : {marketId} has been successfully deleted.");
                    return StatusCode(200, StatusCodes.ReturnStatusObject($"ID : {marketId} has been successfully deleted."));
                }
                else
                {
                    _logger.LogError("Market ID : {0} was not deleted.", marketId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject($"Delete was unsuccessful."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("The Market delete has failed. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("The delete has failed."));
            }
        }

        [HttpGet]
        [Route("Find")]
        public IActionResult Find(int? marketId)
        {
            try
            {
                if (!marketId.HasValue) return BadRequest("Invalid Input.");
                var result = _marketRepository.Find(marketId);

                if (result != null)
                {
                    _logger.LogInformation($"ID : {marketId} has been successfully found.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("Market ID : {0} was not found.", marketId);
                    return StatusCode(404, StatusCodes.ReturnStatusObject("Market Not Found."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to located Market. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Something went wrong."));
            }
        }
    }
}