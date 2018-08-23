
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
    [Route("api/Staffs")]
    public class StaffsController : Controller
    {
        private readonly ApplicationDbContext context;

        public StaffsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Staffs
        [HttpGet]
        public IEnumerable<Staff> GetStaff()
        {
            return context.Staff;
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);

            var staff = await context.Staff.SingleOrDefaultAsync(m => m.Id == id);

            if (staff == null)return NotFound();
           

            return Ok(staff);
        }

        // PUT: api/Staffs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff([FromRoute] int id, [FromBody] StaffModel staff)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);

            if (id != staff.Id)return BadRequest();

            context.Entry(ObjectConverter.ToStaff(staff).Result).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))return NotFound();
               
                throw;
            }

            return NoContent();
        }

        // POST: api/Staffs
        [HttpPost]
        public async Task<IActionResult> PostStaff([FromBody] StaffModel staff)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);

            context.Staff.Add(ObjectConverter.ToStaff(staff).Result);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = staff.Id }, staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);

            var staff = await context.Staff.SingleOrDefaultAsync(m => m.Id == id);
            if (staff == null)return NotFound();

            context.Staff.Remove(staff);
            await context.SaveChangesAsync();

            return Ok(staff);
        }

        private bool StaffExists(int id)
        {
            return context.Staff.Any(e => e.Id == id);
        }
    }
}