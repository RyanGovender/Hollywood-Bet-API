using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.AspNetCore.Cors;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HollywoodBetsAdmin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public  class SportTreeController : ControllerBase
    {
        private ISportTree _sportTree;
        private ILogger<SportTreeController> _logger;
        public SportTreeController(IUnitOfWork sportTree,ILogger<SportTreeController> logger)
        {
            _sportTree = sportTree.SportTreeRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                var result = _sportTree.GetAll();
                if (result.Any())
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


        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] SportTree sportTree)
        {
            try
            {
                var result = _sportTree.Add(sportTree); // returns a boolean based on the number of rows affected

                if (result) // if the post was successfully added to the db it will return true 
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Successfully Added"));
                else // if the post was unsuccesful it will return false
                    return StatusCode(400,StatusCodes.ReturnStatusObject("Insert Failed."));
            }
            catch(Exception eo)
            {
                return StatusCode(400, StatusCodes.ReturnStatusObject("Insert Failed."));
        }
        }

        //https://localhost:44356/api/SportTree/Put?sportId={id}

        [HttpPut]
        [Route("Put")]
        public IActionResult Put([FromBody] SportTree sportTree)
        {
            try
            {
                if (sportTree.Equals(null)) return BadRequest("Oops something went wrong.");// if there was no value entered of sportId it will return a bad request.
                var result = _sportTree.Update(sportTree); // searches the table using the given idea and if the item is found and updated it will return true

                if (result)
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Successfully Updated"));
                else
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Update Failed."));
            }
            catch(Exception e)
            {
                return StatusCode(400, StatusCodes.ReturnStatusObject("Update Failed."));
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int?sportId)
        {
            try
            {
                if (!sportId.HasValue) return BadRequest("Oops something went wrong."); // if there was no value entered of sportId it will return a bad request.
                var result = _sportTree.Delete(sportId);//returns a bool based on a row being effected. 

                if (result)
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Delete successful"));
                else
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Delete Failed."));
            }
            catch(Exception e)
            {
                return StatusCode(400, StatusCodes.ReturnStatusObject("The item could not be Deleted. {0}"));
            }
        }

        [HttpGet]
        [Route("Find")]
        public IActionResult Find(int?sportId)
        {
            try
            {
                if (!sportId.HasValue) return BadRequest("Invalid Input.");
                var result = _sportTree.Find(sportId);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Item not found");
            }
            catch(Exception e)
            {
                return BadRequest("Something went wrong. "+ e.Message);
            }
        }

        [HttpPost]
        [Route("AddSportCountryMapping")]
        public IActionResult AddSportCountryMapping([FromBody] SportCountry sportCountry)
        {
            try
            {
                if (sportCountry.Equals(null)) return StatusCode(400, StatusCodes.ReturnStatusObject("No input provided."));
                var result = _sportTree.AddSportCountryMapping(sportCountry);

                if(result)
                {
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Successfully Added."));
                }
                else
                {
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Insert has Failed."));
                }
            }
            catch(Exception e)
            {

                return StatusCode(400, StatusCodes.ReturnStatusObject("Insert has Failed. " + e.Message));
            }
        }

        [HttpGet]
        [Route("GetAllSportCountry")]
        public IActionResult GetAllSportCountry()
        {
            try
            {
                var result = _sportTree.GetAllSportCountries();
                if (result.Any())
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

        [HttpDelete]
        [Route("DeleteSportCountry")]
        public IActionResult DeleteSportCountry(int? sportCountry)
        {
            try
            {
                if (!sportCountry.HasValue) return BadRequest("Oops something went wrong."); // if there was no value entered of sportId it will return a bad request.
                var result = _sportTree.DeteleSportCountry(sportCountry);//returns a bool based on a row being effected. 

                if (result)
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Delete successful"));
                else
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Delete Failed."));
            }
            catch (Exception e)
            {
                return StatusCode(400, StatusCodes.ReturnStatusObject("The item could not be Deleted. {0}"));
            }
        }

        [HttpPut]
        [Route("PutSportCountry")]
        public IActionResult PutSportCountry([FromBody] SportCountry sportCountry)
        {
            try
            {
                if (sportCountry.Equals(null)) return BadRequest("Oops something went wrong.");// if there was no value entered of sportId it will return a bad request.
                        var result = _sportTree.UpdateSportCountry(sportCountry); // searches the table using the given idea and if the item is found and updated it will return true

                if (result)
                    return StatusCode(200, StatusCodes.ReturnStatusObject("Successfully Updated"));
                else
                    return StatusCode(400, StatusCodes.ReturnStatusObject("Update Failed."));
            }
            catch (Exception e)
            {
                return StatusCode(400, StatusCodes.ReturnStatusObject("Update Failed."));
            }
        }
    }
}