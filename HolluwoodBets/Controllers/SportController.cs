using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class SportController : Controller
    {
        private ISportTree _sportTree;
        public SportController(ISportTree sportTree)
        {
            _sportTree = sportTree;
        }

        [HttpGet]
        public IQueryable<SportTree> Get()
        {

            return _sportTree.GetAll();
        }

    }
}