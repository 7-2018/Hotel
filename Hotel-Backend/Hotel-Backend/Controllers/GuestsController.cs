using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        public GuestRepository guestRepository;
        public GuestsController(DatabaseContext databaseContext)
        {
            this.guestRepository = new GuestRepository(databaseContext);
        }
        // GET: api/<GuestsController>
        [HttpGet]
        public Task<IEnumerable<Guest>> GetAllGuests()
        {
            return guestRepository.GetAllGuests();

        }

        // GET api/<GuestsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GuestsController>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult InsertGuest([FromBody] Guest HotelGuest)
        {
            if (guestRepository.InsertGuest(HotelGuest).Result)
                return Ok(new ActionResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), ResponseMessage.SUCCESSFULL_INSERT.ToString()));
            return BadRequest(new ActionResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), ResponseMessage.BAD_REQUEST.ToString()));
        }

        // PUT api/<GuestsController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update([FromBody] Guest HotelGuest)
        {
            if (guestRepository.UpdateGuest(HotelGuest).Result)
                return Ok(new ActionResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), ResponseMessage.SUCCESSFULL_UPDATE.ToString()));
            return BadRequest(new ActionResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), ResponseMessage.BAD_REQUEST.ToString()));
        }

        // DELETE api/<GuestsController>/5
        [HttpDelete("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(string ID)
        {
            if (guestRepository.DeleteGuest(ID).Result)
                return Ok(new ActionResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), ResponseMessage.SUCCESSFULL_DELETE.ToString()));
            return BadRequest(new ActionResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), ResponseMessage.BAD_REQUEST.ToString()));
        }
    }
}
