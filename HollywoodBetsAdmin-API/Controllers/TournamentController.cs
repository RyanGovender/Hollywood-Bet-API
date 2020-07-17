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
    public class TournamentController : ControllerBase
    {
        private ILogger<TournamentController> _logger;
        private ITournament _tournamentRepository;

        public TournamentController(ITournament tournamentRepository,ILogger<TournamentController> logger)
        {
            _tournamentRepository = tournamentRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _tournamentRepository.GetAll();
                if (result.Any())
                {
                    _logger.LogInformation("Successfully recieved Tournament Data.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("No Tournament data. Data - {0}", result);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No Tournament data."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error recieving data. Error - {0}. Data - {1}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error recieving Tournament data."));
            }
        }
        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] Tournament tournament)
        {
            try
            {
                if (tournament == null) return StatusCode(400, StatusCodes.ReturnStatusObject("No items have been provided."));
                var result = _tournamentRepository.Add(tournament);
                if (result)
                {
                    _logger.LogInformation("Tournament Successfully Added");
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Successfully Added."));
                }
                else
                {
                    _logger.LogError("Tournament has Failed to Add. Tournament - {0}", tournament);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Tournament failed to add."));
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Error Tournament failed to add . Error - {0} , Data - {1}", e.Message, tournament);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error Tournament Failed to Add."));
            }
        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Put([FromBody]Tournament tournament)
        {
            try
            {
                if (tournament.Equals(null)) return StatusCode(400, StatusCodes.ReturnStatusObject("The was no data present."));
                var result = _tournamentRepository.Update(tournament);

                if (result)
                {
                    _logger.LogInformation("Tournament ID : {0} successfully updated.", tournament.TournamentId);
                    return StatusCode(200, StatusCodes.ReturnStatusObject($"{tournament.TournamentId} was Successfully Updated."));
                }
                else
                {
                    _logger.LogError("Tournament ID : {0} was not updated.", tournament.TournamentId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject($"Update was unsuccessful."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("The Tournament update has failed. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("The update has failed."));
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int? tournamentId)
        {
            try
            {
                if (!tournamentId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("No parameter provided."));
                var result = _tournamentRepository.Delete(tournamentId);

                if (result)
                {
                    _logger.LogInformation($"ID : {tournamentId} has been successfully deleted.");
                    return StatusCode(200, StatusCodes.ReturnStatusObject($"ID : {tournamentId} has been successfully deleted."));
                }
                else
                {
                    _logger.LogError("Tournament ID : {0} was not deleted.", tournamentId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject($"Delete was unsuccessful."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("The Tournament delete has failed. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("The delete has failed."));
            }
        }

        [HttpGet]
        [Route("Find")]
        public IActionResult Find(int? tournamentId)
        {
            try
            {
                if (!tournamentId.HasValue) return BadRequest("Invalid Input.");
                var result = _tournamentRepository.Find(tournamentId);

                if (result != null)
                {
                    _logger.LogInformation($"ID : {tournamentId} has been successfully found.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("Tournament ID : {0} was not found.", tournamentId);
                    return StatusCode(404, StatusCodes.ReturnStatusObject("Tournament Not Found."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to located Tournament. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Something went wrong."));
            }
        }

        [HttpPost]
        [Route("AddSportTournamentCountry")]
        public IActionResult AddSportTournamentCountry([FromBody] SportTournament sportTournament)
        {
            try
            {
                if (sportTournament == null) return StatusCode(400, StatusCodes.ReturnStatusObject("No items have been provided."));
                var result = _tournamentRepository.AddSportTournamentCountry(sportTournament);
                if (result)
                {
                    _logger.LogInformation("Tournament Successfully Added");
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Successfully Added."));
                }
                else
                {
                    _logger.LogError("Tournament has Failed to Add. Tournament - {0}", sportTournament);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Tournament mapping failed to add."));
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Error Tournament failed to add . Error - {0} , Data - {1}", e.Message, sportTournament);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error Tournament mapping Failed to Add."));
            }
        }

        [HttpGet]
        [Route("GetAllSportTournmentCountries")]
        public IActionResult GetAllSportTournmentCountries()
        {
            try
            {
                var result = _tournamentRepository.GetAllSportTournmentCountries();
                if (result.Any())
                {
                    _logger.LogInformation("Successfully recieved Tournament Data.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("No Tournament data. Data - {0}", result);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No Tournament data."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error recieving data. Error - {0}. Data - {1}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error recieving Tournament data."));
            }
        }

    }
}