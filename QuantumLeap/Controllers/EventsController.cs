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
    public class EventsController : ControllerBase
    {
        readonly EventRepository _eventRepository;

        public EventsController()
        {
            _eventRepository = new EventRepository();
        }

        [HttpGet]
        public ActionResult GetAllEvents()
        {
            var events = _eventRepository.GetAllEvents();

            return Ok(events);
        }

        [HttpPost("add")]
        public ActionResult AddEvent(CreateEventRequest createRequest)
        {
            var newEvent = _eventRepository.AddEvent(
                createRequest.Description,
                createRequest.Location,
                createRequest.Year,
                createRequest.IsCorrect);

            return Created($"/api/event/{newEvent.Id}", newEvent);
        }

        [HttpPut("{eventId}")]
        public ActionResult CompleteEvent(Event eventToUpdate)
        {
            var completedEvent = _eventRepository.CompleteEvent(eventToUpdate);

            return Ok(completedEvent);
        }
    }
}