using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.BusinessLayer;
using HollywoodBets.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodBets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class EventController : Controller
    {
        [HttpGet]
        public IEnumerable<Event> Get(int? tournamentId)
        {
            return SportCountryBusiness.GetAllEvents(tournamentId);
        }

    }
}