using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.BusinessLayer;
using HollywoodBets.DAL;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodBets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class TournamentsController : Controller
    {
        private ITournament _tournamentRepository;
        public TournamentsController(ITournament tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }
       
        //https://localhost:44330/api/sportcountry/?sportId={sportId}&countryId={countryId}
        [HttpGet]
        public IQueryable<Tournament> Get(int? sportId,int?countryId)
        {
            return _tournamentRepository.GetAllTournamentsForSportBasedOnCountry(sportId, countryId);
        }

        [Route("GetTournament")]
        public Tournament GetTournament(int? tournamentId)
        {
            return _tournamentRepository.GetTournament(tournamentId);
        }

    }
}