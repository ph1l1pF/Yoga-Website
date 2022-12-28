using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YogaBackendAPI.Models;
using YogaBackendAPI.Services;

namespace YogaBackendAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsageDataController : ControllerBase
    {

        private readonly IUsageDataService _usageDataService;

        public UsageDataController(IUsageDataService usageDataService)
        {
            _usageDataService = usageDataService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Message>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetAllMessages")]
        public IActionResult GetAllMessages()
        {
            try
            {
                return new OkObjectResult(_usageDataService.GetAllMessages());
            }
            catch (Exception e) 
            {
                Console.WriteLine("Fehler: " + e);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("StoreVisit")]
        public IActionResult StoreVisit([FromQuery] string componentName)
        {
            try
            {
                _usageDataService.StoreVisit(componentName);
            }
            catch (Exception e) 
            {
                Console.WriteLine("Fehler: " + e);
                return new StatusCodeResult(500);
            }

            return new OkObjectResult("Visit stored.");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Visit>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetAllVisits")]
        public IActionResult GetAllVisits()
        {
            try
            {
                return new OkObjectResult(_usageDataService.GetAllVisits());
            }
            catch (Exception e) 
            {
                Console.WriteLine("Fehler: " + e);
                return new StatusCodeResult(500);
            }
        }
    }
}
