using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories.ReceptionistRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController : ControllerBase
    {
        public ReceptionistRepository receptionistRepository;
        public ReceptionistController(DatabaseContext databaseContext)
        {
            this.receptionistRepository = new ReceptionistRepository(databaseContext);
        }
        // GET api/<ReceptionistController>/5
        [HttpGet("{email}")]
        public Task<Receptionist>GetReceptionistByEmail(string email)
        {
            return receptionistRepository.GetReceptionistByUsername(email);   
        }
    }
}
