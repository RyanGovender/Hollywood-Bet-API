using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.DAL;
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
    public class SportController : Controller
    {
        private ISportTree _sportTree;
        private ILogger<SportController> _logger;
        public SportController(ISportTree sportTree, ILogger<SportController> logger)
        {
            _sportTree = sportTree;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _sportTree.GetAll();
                if(result.Any())
                {
                    _logger.LogInformation("Successfully retrieved.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogInformation("No items found.");
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No items available."));
                }
            }
            catch
            {
                _logger.LogInformation("Failed to find items.");
                return StatusCode(400, StatusCodes.ReturnStatusObject("Failed to retrive items."));
            }
        }

    }
}