using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DadayaAPI.Data;

namespace DadayaAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Notices")]
    public class NoticesController : Controller
    {
        private readonly ApplicationDbContext context;

        public NoticesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Notices
        [HttpGet]
        public IEnumerable<Notice> GetNotices()
        {
            return context.Notices;
        }

        // GET: api/Notices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notice = await context.Notices.SingleOrDefaultAsync(m => m.Id == id);

            if (notice == null)
            {
                return NotFound();
            }

            return Ok(notice);
        }

        // PUT: api/Notices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotice([FromRoute] int id, [FromBody] Notice notice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notice.Id)
            {
                return BadRequest();
            }

            context.Entry(notice).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notices
        [HttpPost]
        public async Task<IActionResult> PostNotice([FromBody] Notice notice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Notices.Add(notice);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetNotice", new { id = notice.Id }, notice);
        }

        // DELETE: api/Notices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notice = await context.Notices.SingleOrDefaultAsync(m => m.Id == id);
            if (notice == null)
            {
                return NotFound();
            }

            context.Notices.Remove(notice);
            await context.SaveChangesAsync();

            return Ok(notice);
        }

        private bool NoticeExists(int id)
        {
            return context.Notices.Any(e => e.Id == id);
        }
    }
}