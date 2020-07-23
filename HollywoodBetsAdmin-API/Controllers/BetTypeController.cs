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
    public class BetTypeController : ControllerBase
    {
        private IBetType _betTypeRepository;
        private ILogger<BetTypeController> _logger;

        public BetTypeController(IUnitOfWork betType,ILogger<BetTypeController> logger)
        {
            _logger = logger;
            _betTypeRepository = betType.BetTypeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _betTypeRepository.GetAll();
                if (result.Any())
                {
                    _logger.LogInformation("Successfully recieved BetType Data.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("No country BetType. Data - {0}", result);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No BetType data."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error recieving data. Error - {0}. Data - {1}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error recieving BetType data."));
            }
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] BetType betType)
        {
            try
            {
                if (betType == null) return StatusCode(400, StatusCodes.ReturnStatusObject("No items have been provided."));
                var result = _betTypeRepository.Add(betType);
                if (result)
                {
                    _logger.LogInformation("Bet Type Successfully Added");
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Successfully Added."));
                }
                else
                {
                    _logger.LogError("Bet Type has Failed to Add. Bet Type - {0}", betType);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Bet Type failed to add."));
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Error Bet Type failed to add . Error - {0} , Data - {1}", e.Message, betType);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error Bet Type Failed to Add."));
            }
        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Put([FromBody]BetType betType)
        {
            try
            {
                if (betType.Equals(null)) return StatusCode(400, StatusCodes.ReturnStatusObject("The was no data present."));
                var result = _betTypeRepository.Update(betType);

                if (result)
                {
                    _logger.LogInformation("Bet Type ID : {0} successfully updated.", betType.BetTypeId);
                    return StatusCode(200, StatusCodes.ReturnStatusObject($"{betType.BetTypeName} was Successfully Updated."));
                }
                else
                {
                    _logger.LogError("Bet Type : {0} was not updated.", betType.BetTypeId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject($"Update was unsuccessful."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("The Bet Type update has failed. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("The update has failed."));
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int? betTypeId)
        {
            try
            {
                if (!betTypeId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("No parameter provided."));
                var result = _betTypeRepository.Delete(betTypeId);

                if (result)
                {
                    _logger.LogInformation($"ID : {betTypeId} has been successfully deleted.");
                    return StatusCode(200, StatusCodes.ReturnStatusObject($"ID : {betTypeId} has been successfully deleted."));
                }
                else
                {
                    _logger.LogError("Bet Type ID : {0} was not deleted.", betTypeId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject($"Delete was unsuccessful."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("The Bet Type delete has failed. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("The delete has failed."));
            }
        }

        [HttpGet]
        [Route("Find")]
        public IActionResult Find(int? betTypeId)
        {
            try
            {
                if (!betTypeId.HasValue) return BadRequest("Invalid Input.");
                var result = _betTypeRepository.Find(betTypeId);

                if (result != null)
                {
                    _logger.LogInformation($"ID : {betTypeId} has been successfully found.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("Bet Type ID : {0} was not found.", betTypeId);
                    return StatusCode(404, StatusCodes.ReturnStatusObject("Bet Type Not Found."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to located Bet Type. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Something went wrong."));
            }
        }

        [HttpPost]
        [Route("AddTournamentBetTypes")]
        public IActionResult AddTournamentBetTypes([FromBody] TournamentBetType tournamentBetType)
        {
            try
            {
                if (tournamentBetType == null) return StatusCode(400, StatusCodes.ReturnStatusObject("No items have been provided."));
                var result = _betTypeRepository.AddTournamentBetTypes(tournamentBetType);
                if (result)
                {
                    _logger.LogInformation("Bet Type Mapping Successfully Added");
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Successfully Added."));
                }
                else
                {
                    _logger.LogError("Bet Type has Failed to Add. Bet Type - {0}", tournamentBetType);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Bet Type Mapping failed to add."));
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Error Bet Type failed to add . Error - {0} , Data - {1}", e.Message, tournamentBetType);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error Bet Type Mapping Failed to Add."));
            }
        }

        [HttpGet]
        [Route("GetAllTournamentBetTypes")]
        public IActionResult GetAllTournamentBetTypes()
        {
            try
            {
                var result = _betTypeRepository.GetAllTournamentBetTypes();
                if (result.Any())
                {
                    _logger.LogInformation("Successfully recieved BetType Data.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("No country BetType. Data - {0}", result);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No BetType data."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error recieving data. Error - {0}. Data - {1}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error recieving BetType data."));
            }
        }

    }
}