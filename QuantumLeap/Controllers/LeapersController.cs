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
    public class LeapersController : ControllerBase
    {
        readonly LeaperRepository _leaperRepository;

        public LeapersController()
        {
            _leaperRepository = new LeaperRepository();
        }

        [HttpGet]
        public ActionResult GetAllLeapers()
        {
            var leapers = _leaperRepository.GetAllLeapers();

            return Ok(leapers);
        }

        [HttpPost("add")]
        public ActionResult AddLeaper(CreateLeaperRequest createRequest)
        {
            var newLeaper = _leaperRepository.AddLeaper(
                createRequest.Name,
                createRequest.Age,
                createRequest.Budget,
                createRequest.HomeYear);

            return Created($"/api/leaper/{newLeaper.Id}", newLeaper);
        }
    }
}