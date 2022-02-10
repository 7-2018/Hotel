using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories.ReservationRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        public ReservationRepository reservationRepository;
        public ReservationsController(DatabaseContext databaseContext)
        {
            this.reservationRepository = new ReservationRepository(databaseContext);
        }
        // GET: api/<ReservationsController>
        [HttpGet]
        [HttpGet]
        public Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return reservationRepository.GetAllReservations();

        }

        // POST api/<ReservationsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult InsertReservation([FromBody] Reservation HotelReservation)
        {
            if (reservationRepository.InsertReservation(HotelReservation).Result)
                return Ok(new ActionResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), ResponseMessage.SUCCESSFULL_INSERT.ToString()));
            return BadRequest(new ActionResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), ResponseMessage.BAD_REQUEST.ToString()));
        }

        // PUT api/<ReservationsController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update([FromBody] Reservation HotelReservation)
        {
            if (reservationRepository.UpdateReservation(HotelReservation).Result)
                return Ok(new ActionResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), ResponseMessage.SUCCESSFULL_UPDATE.ToString()));
            return BadRequest(new ActionResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), ResponseMessage.BAD_REQUEST.ToString()));
        }

        // DELETE api/<ReservationsController>/5
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(string GuestID, int HotelRoomNumber, DateTime CheckInDate)
        {
            if (reservationRepository.DeleteReservation(GuestID, HotelRoomNumber, CheckInDate).Result)
                return Ok(new ActionResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), ResponseMessage.SUCCESSFULL_DELETE.ToString()));
            return BadRequest(new ActionResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), ResponseMessage.BAD_REQUEST.ToString()));
        }
    }
}
