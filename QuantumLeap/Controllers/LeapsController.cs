using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuantumLeap.Data;
using QuantumLeap.Models;

namespace QuantumLeap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeapsController : ControllerBase
    {
        readonly LeapRepository _leapRepository;

        public LeapsController()
        {
            _leapRepository = new LeapRepository();
        }

        [HttpPost("add")]
        public ActionResult AddLeap(CreateLeapRequest createRequest)
        {
            var newLeap = _leapRepository.AddLeap(
                createRequest.LeaperId);

            return Created($"/api/leap/{newLeap.Id}", newLeap);
        }
    }
}