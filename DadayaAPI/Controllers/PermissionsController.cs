
namespace DadayaAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DadayaAPI.Data;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Produces("application/json")]
    [Route("api/Permissions")]
    public class PermissionsController : Controller
    {
        private readonly ApplicationDbContext context;

        public PermissionsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Permissions
        [HttpGet]
        public IEnumerable<Permission> GetPermissions()
        {
            return context.Permissions;
        }

        // GET: api/Permissions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermission([FromRoute] int id)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            var permission = await context.Permissions.SingleOrDefaultAsync(m => m.Id == id);

            if (permission == null)
                return NotFound();
            return Ok(permission);
        }

        // PUT: api/Permissions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermission([FromRoute] int id, [FromBody] Permission permission)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            if (id != permission.Id)return BadRequest();
            context.Entry(permission).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionExists(id))return NotFound();
                    throw;
            }

            return NoContent();
        }

        // POST: api/Permissions
        [HttpPost]
        public async Task<IActionResult> PostPermission([FromBody] Permission permission)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            context.Permissions.Add(permission);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetPermission", new { id = permission.Id }, permission);
        }

        // DELETE: api/Permissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           var permission = await context.Permissions.SingleOrDefaultAsync(m => m.Id == id);
            if (permission == null)return NotFound();
            context.Permissions.Remove(permission);
            await context.SaveChangesAsync();

            return Ok(permission);
        }

        private bool PermissionExists(int id)
        {
            return context.Permissions.Any(e => e.Id == id);
        }
    }
}