using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Persistence;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/Events")]
    public class EventsController : ControllerBase
    {
        private readonly EventsDbContext _context;
        public EventsController(EventsDbContext context)
        {
            _context = context;
        }


        [HttpGet]

        public IActionResult GetAll()
        {
            var Events = _context.EventsList.Where(e => !e.isDeleted).ToList();
            return Ok(Events);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Events = _context.EventsList.SingleOrDefault(e => e.id == id);
            if (Events == null)
            {
                return NotFound();
            }
            return Ok(Events);
        }


        [HttpPost]
        public IActionResult Post([FromBody]Event evento)
        {
            _context.EventsList.Add(evento);

            return CreatedAtAction(nameof(GetById), new { id = evento.id }, evento);
        }



        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Event input)
        {
            var Events = _context.EventsList.SingleOrDefault(e => e.id == id);
            if (Events == null)
            {
                return NotFound();
            }

            Events.Update(input.Title, input.Description, input.StartDate, input.EndDate);


            return NoContent();
        }




        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id, Event evento)
        {
            var Events = _context.EventsList.SingleOrDefault(e => e.id == id);
            if (Events == null)
            {
                return NotFound();
            }

            Events.Delete();
            return NoContent();
        }

    }
}