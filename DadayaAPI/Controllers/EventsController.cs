
namespace DadayaAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DadayaAPI.Data;
    using DadayaAPI.Models;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext context;

        public EventsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<Event> GetEvents()
        {
            return context.Events;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            var @event = await context.Events.SingleOrDefaultAsync(m => m.Id == id);
            if (@event == null)return NotFound();
            return Ok(@event);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] EventModel @event)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            if (id != @event.Id)return BadRequest();
            context.Entry(ObjectConverter.ToEvent(@event).Result).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))return NotFound();
                    throw;
            }

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] EventModel @event)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            context.Events.Add(ObjectConverter.ToEvent(@event).Result);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
          

            var @event = await context.Events.SingleOrDefaultAsync(m => m.Id == id);
            if (@event == null)return NotFound();
            context.Events.Remove(@event);
            await context.SaveChangesAsync();

            return Ok(@event);
        }

        private bool EventExists(int id)
        {
            return context.Events.Any(e => e.Id == id);
        }
    }
}