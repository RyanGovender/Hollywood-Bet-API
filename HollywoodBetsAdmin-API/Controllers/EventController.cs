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
    public class EventController : ControllerBase
    {
        private ILogger<EventController> _logger;
        private IEvent _eventRepository;
        private IOdds _oddsRepository;

        public EventController(ILogger<EventController> logger, IEvent eventRepository, IOdds oddsRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _oddsRepository = oddsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _eventRepository.GetAll();
                if (result.Any())
                {
                    _logger.LogInformation("Successfully recieved Event Data.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("No Event data. Data - {0}", result);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No Event data."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error recieving data. Error - {0}. Data - {1}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error recieving Event data."));
            }
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] Event @event)
        {
            try
            {
                if (@event == null) return StatusCode(400, StatusCodes.ReturnStatusObject("No items have been provided."));
                var result = _eventRepository.Add(@event);
                if (result)
                {
                    _logger.LogInformation("Event Successfully Added");
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Successfully Added."));
                }
                else
                {
                    _logger.LogError("Event has Failed to Add. Event - {0}", @event);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Event failed to add."));
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Error Event failed to add . Error - {0} , Data - {1}", e.Message, @event);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error Event Failed to Add."));
            }
        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Put([FromBody]Event @event)
        {
            try
            {
                if (@event.Equals(null)) return StatusCode(400, StatusCodes.ReturnStatusObject("The was no data present."));
                var result = _eventRepository.Update(@event);

                if (result)
                {
                    _logger.LogInformation("Event ID : {0} successfully updated.", @event.EventId);
                    return StatusCode(200, StatusCodes.ReturnStatusObject($"{@event.EventId} was Successfully Updated."));
                }
                else
                {
                    _logger.LogError("Event ID : {0} was not updated.", @event.EventId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject($"Update was unsuccessful."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("The Event update has failed. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("The update has failed."));
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int? eventId)
        {
            try
            {
                if (!eventId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("No parameter provided."));
                var result = _eventRepository.Delete(eventId);

                if (result)
                {
                    _logger.LogInformation($"ID : {eventId} has been successfully deleted.");
                    return StatusCode(200, StatusCodes.ReturnStatusObject($"ID : {eventId} has been successfully deleted."));
                }
                else
                {
                    _logger.LogError("Event ID : {0} was not deleted.", eventId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject($"Delete was unsuccessful."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("The Event delete has failed. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("The delete has failed."));
            }
        }

        [HttpGet]
        [Route("Find")]
        public IActionResult Find(int? eventId)
        {
            try
            {
                if (!eventId.HasValue) return BadRequest("Invalid Input.");
                var result = _eventRepository.Find(eventId);

                if (result != null)
                {
                    _logger.LogInformation($"ID : {eventId} has been successfully found.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("Event ID : {0} was not found.", eventId);
                    return StatusCode(404, StatusCodes.ReturnStatusObject("Event Not Found."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to located Event. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Something went wrong."));
            }
        }

        [HttpPost]
        [Route("AddOdds")]
        public IActionResult AddOdds([FromBody] Odds odds)
        {
            try
            {
                if (odds == null) return StatusCode(400, StatusCodes.ReturnStatusObject("No items have been provided."));
                var result = _eventRepository.AddOdds(odds);
                if (result)
                {
                    _logger.LogInformation("Odds Successfully Added");
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Successfully Added."));
                }
                else
                {
                    _logger.LogError("Odds has Failed to Add. Event - {0}", odds);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Odds failed to add."));
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Error Odds failed to add . Error - {0} , Data - {1}", e.Message, odds);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error Odds Failed to Add." + e.Message));
            }
        }

        [HttpGet]
        [Route("GetAllOdds")]
        public IActionResult GetAllOdds()
        {
            try
            {
                var result = _oddsRepository.GetAllOdds();
                if (result.Any())
                {
                    _logger.LogInformation("Successfully recieved Event Data.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("No Event data. Data - {0}", result);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No Event data."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error recieving data. Error - {0}. Data - {1}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error recieving Event data."));
            }
        }
    }
}