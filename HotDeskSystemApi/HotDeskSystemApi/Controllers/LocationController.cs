using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotDeskSystemApi.Data;
using HotDeskSystemApi.Business.ViewModels;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace HotDeskSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private Business.Domains.ILocationServices _locationServicesDomain;

        public LocationController(Business.Domains.ILocationServices domain)
        {
            _locationServicesDomain = domain;
        }

        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpPost("CreateNewLocation")]
        public IActionResult CreateNewLocation(LocationModel locationModel, int userId)
        {
            HttpStatusCode response; LocationModel? content;
            (content, response) = _locationServicesDomain.CreateNewLocation(locationModel, userId);
            switch (response)
            {
                case HttpStatusCode.OK:
                    return Ok(content);
                case HttpStatusCode.Forbidden:
                    return Forbid();
                default:
                    return BadRequest();
            }
        }

        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpDelete("DeleteLocation")]
        public IActionResult DeleteLocation(int locationId, int userId)
        {
            var response = _locationServicesDomain.DeleteLocation(locationId, userId);
            switch (response)
            {
                case HttpStatusCode.OK:
                    return Ok();
                case HttpStatusCode.Forbidden:
                    return Forbid();
                case HttpStatusCode.NotFound:
                    return NotFound();
                default:
                    return BadRequest();
            }
        }
    }
}
