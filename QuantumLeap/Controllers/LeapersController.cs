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
        [HttpPost]
        public ActionResult AddLeaper(CreateLeaperRequest createRequest)
        {
            var respository = new LeaperRepository();

            var newLeaper = respository.AddLeaper(
                createRequest.Name,
                createRequest.Age);

            return Created($"/api/leaper/{newLeaper.Id}", newLeaper);
        }
    }
}