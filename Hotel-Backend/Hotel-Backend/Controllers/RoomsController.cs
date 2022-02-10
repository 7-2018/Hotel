using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories.RoomRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Hotel_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        public RoomRepository roomRepository;
        public RoomsController(DatabaseContext databaseContext)
        {
            this.roomRepository = new RoomRepository(databaseContext);
        }
        // GET: api/<RoomsController>
        [HttpGet]
        public Task<IEnumerable<Room>> GetAllRooms()
        {
            return roomRepository.GetAllRooms();
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult InsertRoom([FromBody] Room HotelRoom)
        {
            if (roomRepository.InsertRoom(HotelRoom).Result)
                return Ok(StatusCodes.Status200OK);
            return BadRequest(StatusCodes.Status400BadRequest);
        }

        // PUT api/<RoomsController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update([FromBody] Room HotelRoom)
        {
            if (roomRepository.UpdateRoom(HotelRoom).Result)
                return Ok(new ActionResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), ResponseMessage.SUCCESSFULL_UPDATE.ToString()));
            return BadRequest(new ActionResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), ResponseMessage.BAD_REQUEST.ToString()));
        }

        [HttpDelete("{RoomNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(int RoomNumber)
        {
            if (roomRepository.DeleteRoom(RoomNumber).Result)
                return Ok(StatusCodes.Status200OK);
            return BadRequest(StatusCodes.Status400BadRequest);
        }
    }
}
