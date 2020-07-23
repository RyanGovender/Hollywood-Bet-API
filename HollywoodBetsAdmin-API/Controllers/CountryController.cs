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
using SQLitePCL;

namespace HollywoodBetsAdmin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CountryController : ControllerBase
    {
        private ILogger<CountryController> _logger;
        private ICountry _countryRepository;

        public CountryController(IUnitOfWork countryRepository, ILogger<CountryController> logger)
        {
            _logger = logger;
            _countryRepository = countryRepository.CountryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _countryRepository.GetAll();
                if(result.Any())
                {
                    _logger.LogInformation("Successfully recieved Country Data.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("No country data. Data - {0}",result);
                    return StatusCode(400, StatusCodes.ReturnStatusObject("No country data."));
                }
            }
            catch(Exception e)
            {
                _logger.LogError("Error recieving data. Error - {0}. Data - {1}",e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error recieving Country data."));
            }
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] Country country)
        {
            try
            {
                if (country == null) return StatusCode(400, StatusCodes.ReturnStatusObject("No items have been provided."));
                var result = _countryRepository.Add(country);
                if(result)
                {
                    _logger.LogInformation("Country Successfully Added");
                    return StatusCode(200,StatusCodes.ReturnStatusObject("Successfully Added."));
                }
                else
                {
                    _logger.LogError("Country has Failed to Add. Country - {0}", country);
                    return StatusCode(400,StatusCodes.ReturnStatusObject("Country failed to add."));
                }
                
            }
            catch(Exception e)
            {
                _logger.LogError("Error country failed to add . Error - {0} , Data - {1}",e.Message,country);
                return StatusCode(400, StatusCodes.ReturnStatusObject("Error Country Failed to Add."));
            }
        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Put([FromBody]Country country)
        {
            try
            {
                if (country.Equals(null)) return StatusCode(400, StatusCodes.ReturnStatusObject("The was no data present."));
                var result = _countryRepository.Update(country);

                if (result)
                {
                    _logger.LogInformation("Country ID : {0} successfully updated.",country.CountryId);
                    return StatusCode(200, StatusCodes.ReturnStatusObject($"{country.CountryName} was Successfully Updated."));
                }
                else
                {
                    _logger.LogError("Country ID : {0} was not updated.",country.CountryId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject($"Update was unsuccessful."));
                }
            }
            catch(Exception e)
            {
                _logger.LogError("The Country update has failed. Error - {0}",e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("The update has failed."));
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int?countryId)
        {
            try
            {
                if (!countryId.HasValue) return StatusCode(400, StatusCodes.ReturnStatusObject("No parameter provided."));
                var result = _countryRepository.Delete(countryId);

                if(result)
                {
                    _logger.LogInformation($"ID : {countryId} has been successfully deleted.");
                    return StatusCode(200, StatusCodes.ReturnStatusObject($"ID : {countryId} has been successfully deleted."));
                }
                else
                {
                    _logger.LogError("Country ID : {0} was not deleted.",countryId);
                    return StatusCode(400, StatusCodes.ReturnStatusObject($"Delete was unsuccessful."));
                }
            }
            catch(Exception e)
            {
                _logger.LogError("The Country delete has failed. Error - {0}", e.Message);
                return StatusCode(400, StatusCodes.ReturnStatusObject("The delete has failed."));
            }
        }

        [HttpGet]
        [Route("Find")]
        public IActionResult Find(int? countryId)
        {
            try
            {
                if (!countryId.HasValue) return BadRequest("Invalid Input.");
                var result = _countryRepository.Find(countryId);

                if (result != null)
                {
                    _logger.LogInformation($"ID : {countryId} has been successfully found.");
                    return Ok(result);
                }
                else
                {
                    _logger.LogError("Country ID : {0} was not found.", countryId);
                    return StatusCode(404,StatusCodes.ReturnStatusObject("Country Not Found."));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to located Country. Error - {0}", e.Message);
                return StatusCode(400,StatusCodes.ReturnStatusObject("Something went wrong."));
            }
        }


    }
}