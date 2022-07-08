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
    public class DeskController : ControllerBase
    {
        private Business.Domains.IDeskServices _deskServicesDomain;

        public DeskController(Business.Domains.IDeskServices domain)
        {
            _deskServicesDomain = domain;
        }

        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "User,Admin")]
        [HttpGet("GetDesksByLocation")]
        public IActionResult GetDesksByLocation(int userId, int locationId)
        {
            List<DeskModel>? content = _deskServicesDomain.GetDesksByLocation(userId, locationId);
            return Ok(content);
        }
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "User,Admin")]
        [HttpGet("GetAvailableDesksAtDate")]
        public IActionResult GetAvailableDesksAtDate(DateTime date)
        {
            List<DeskModel>? content = _deskServicesDomain.GetAvailableDesksAtDate(date);
            return Ok(content);
        }
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "User,Admin")]
        [HttpGet("GetUnAvailableDesksAtDate")]
        public IActionResult GetUnAvailableDesksAtDate(DateTime date)
        {
            List<DeskModel>? content = _deskServicesDomain.GetUnAvailableDesksAtDate(date);
            return Ok(content);
        }
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpPost("CreateNewDesk")]
        public IActionResult CreateNewDesk(DeskModel desk, int userId)
        {
            HttpStatusCode response; DeskModel? content;
            (content, response) = _deskServicesDomain.CreateNewDesk(desk, userId);
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
        [HttpDelete("DeleteDesk")]
        public IActionResult DeleteDesk(int deskId, int userId)
        {
            var response = _deskServicesDomain.DeleteDesk(deskId, userId); 
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
