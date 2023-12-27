using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;


namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/Events")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public EventsController(AppDbContext context)
        {
            appDbContext = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetEvents()
        {
            var events = await appDbContext.Events.ToListAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Event>>> GetEventById(int id)
        {
            var events = await appDbContext.Events.FirstOrDefaultAsync(e => e.id == id);
            if (events != null)
            {
                return Ok(events);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<List<Event>>> AddEvent(Event newEvent)
        {

            if (newEvent != null)
            {
                if (!string.IsNullOrWhiteSpace(newEvent.StartDateString))
                {
                    newEvent.StartDate = DateTime.ParseExact(newEvent.StartDateString, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                }

                if (!string.IsNullOrWhiteSpace(newEvent.EndDateString))
                {
                    newEvent.EndDate = DateTime.ParseExact(newEvent.EndDateString, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                }


                appDbContext.Events.Add(newEvent);
                await appDbContext.SaveChangesAsync();
                return await appDbContext.Events.ToListAsync();
            }
            return BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Event>>> UpdateEvent(Event updatedEvent, int id)
        {

            var events = await appDbContext.Events.FirstOrDefaultAsync(e => e.id == id);
            if (updatedEvent != null)
            {
                if (events != null)
                {
                    events.Title = updatedEvent.Title;
                    events.Description = updatedEvent.Description;
                    events.StartDate = updatedEvent.StartDate;
                    events.EndDate = updatedEvent.EndDate;
                    await appDbContext.SaveChangesAsync();
                }
            }
            return BadRequest();


        }




        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Event>>> DeleteEvent(int id)
        {

            var events = await appDbContext.Events.FirstOrDefaultAsync(e => e.id == id);
            if (events != null)
            {
                appDbContext.Events.Remove(events);
                await appDbContext.SaveChangesAsync();
            }

            return NoContent();
        }

    }
}