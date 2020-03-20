using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.DAL;
using HollywoodBets.Models;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodBets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportController : Controller
    {

        [HttpGet]
        public IEnumerable<SportTree> Get()
        {
            return Data.Sports.ToArray();
        }
    }
}