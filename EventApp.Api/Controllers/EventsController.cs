using EventApp.Api.Models;
using EventApp.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
   
        }


        [HttpGet]
        public IActionResult GetEvents()
        {
            var events= _context.Events.OrderByDescending(e => e.Id).ToList();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var evt = _context.Events.Find(id);
            if (evt == null)
            {
                return NotFound();
            }

            return Ok(evt);
        }

        [HttpPost]
        public IActionResult CreateEvent(EventDto eventDto)
        {
            var evt = new Event
            {
                Title = eventDto.Title,
                Description = eventDto.Description,
                Start = eventDto.Start,
                End = eventDto.End,
                AllDay = eventDto.AllDay,
                CreatedAt = DateTime.Now,
            };

            _context.Events.Add(evt);
            _context.SaveChanges();

            return Ok(evt);
        }

        [HttpPut("{id}")]
        public IActionResult EditEvent(int id, EventDto eventDto)
        {
            var evt = _context.Events.Find(id); 
            if (evt == null)
            {
                return NotFound();
            }

            evt.Title = eventDto.Title;
            evt.Description = eventDto.Description;
            evt.Start = eventDto.Start;
            evt.End = eventDto.End;
            evt.AllDay = eventDto.AllDay;

            _context.SaveChanges();

            return Ok(evt);
        }

        [HttpDelete("{id}")]
        public  IActionResult DeleteEvent(int id)
        {
            var evt = _context.Events.Find(id);
            if (evt == null)
            {
                return NotFound();
            }

            _context.Events.Remove(evt);
            _context.SaveChanges();

            return Ok();
        }
    }
}
