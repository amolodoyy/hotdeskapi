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
    public class ReservationController : ControllerBase
    {
        private Business.Domains.IReservationServices _reservationServicesDomain;

        public ReservationController(Business.Domains.IReservationServices domain)
        {
            _reservationServicesDomain = domain;
        }
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,User")]
        [HttpPost("CreateReservation")]
        public IActionResult CreateReservation(ReservationModel reservationModel)
        {
            HttpStatusCode response; ReservationModel? content;
            (content, response) = _reservationServicesDomain.CreateReservation(reservationModel);
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
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
        [HttpPut("EditReservation")]
        public IActionResult EditReservation(ReservationModel reservationModel)
        {
            HttpStatusCode response; ReservationModel? content;
            (content, response) = _reservationServicesDomain.EditReservation(reservationModel);
            switch (response)
            {
                case HttpStatusCode.OK:
                    return Ok(content);
                case HttpStatusCode.NotFound:
                    return NotFound();
                case HttpStatusCode.Forbidden:
                    return Forbid();
                default:
                    return BadRequest();
            }
        }
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpGet("GetReservationByLocation")]
        public IActionResult GetReservationsByLocation(int locationId)
        {
            List<ReservationModel>? content = _reservationServicesDomain.GetReservationsByLocation(locationId);
            return Ok(content);
        }
    }
}
