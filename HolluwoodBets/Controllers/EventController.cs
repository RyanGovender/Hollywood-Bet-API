using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.BusinessLayer;
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
        public IQueryable<Event> Get(int? tournamentId)
        {
            _logger.LogInformation("Get events for tournament ID : {0}",tournamentId);
            return _eventRepository.GetAllEventsForTournament(tournamentId);
        }

       [HttpPost]
       [Route("Create")]
       public TestTable Create([FromBody] TestTable testTable)
        {
            
            return _eventRepository.Create(testTable);
        }

    }
}