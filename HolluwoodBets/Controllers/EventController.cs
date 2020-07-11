using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.BusinessLayer;
using HollywoodBets.Models.Model;
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
    public class EventController : Controller
    {
        private IEvent _eventRepository;
        private readonly ILogger<EventController> _logger;
        public EventController(IEvent eventRepository, ILogger<EventController> logger)
        {
            _eventRepository = eventRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int? tournamentId)
        {
            try
            {
                if (!tournamentId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("Retriving events failed."));

                var result = _eventRepository.GetAllEventsForTournament(tournamentId);
                if(result.Any())
                {
                    _logger.LogInformation("Get events for tournament ID : {0} successful", tournamentId);
                    return Ok(result);
                }
                else
                {
                    _logger.LogInformation("Get events for tournament ID : {0} has no items", tournamentId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Retriving events failed."));
                }
            }
            catch(Exception e)
            {
                _logger.LogInformation("Get events for tournament ID : {0} has failed", tournamentId);
                return StatusCode(400, StatusCodes.ReturnStatusObject($"Retriving events failed. Error : {e.Message}"));
            }
           
        }

       [HttpPost]
       [Route("Create")]
       public TestTable Create([FromBody] TestTable testTable)
        {
            
            return _eventRepository.Create(testTable);
        }

    }
}