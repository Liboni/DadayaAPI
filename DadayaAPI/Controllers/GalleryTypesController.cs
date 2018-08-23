
namespace DadayaAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DadayaAPI.Data;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Produces("application/json")]
    [Route("api/GalleryTypes")]
    public class GalleryTypesController : Controller
    {
        private readonly ApplicationDbContext context;

        public GalleryTypesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/GalleryTypes
        [HttpGet]
        public IEnumerable<GalleryType> GetGalleryTypes()
        {
            return context.GalleryTypes;
        }

        // GET: api/GalleryTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGalleryType([FromRoute] byte id)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            var galleryType = await context.GalleryTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (galleryType == null)return NotFound();
            return Ok(galleryType);
        }

        // PUT: api/GalleryTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryType([FromRoute] byte id, [FromBody] GalleryType galleryType)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            if (id != galleryType.Id)return BadRequest();
            context.Entry(galleryType).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryTypeExists(id))return NotFound();
                throw;
            }

            return NoContent();
        }
        
        // POST: api/GalleryTypes
        [HttpPost]
        public async Task<IActionResult> PostGalleryType([FromBody] GalleryType galleryType)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            context.GalleryTypes.Add(galleryType);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GalleryTypeExists(galleryType.Id))return new StatusCodeResult(StatusCodes.Status409Conflict);
                throw;
            }
            return CreatedAtAction("GetGalleryType", new { id = galleryType.Id }, galleryType);
        }

        // DELETE: api/GalleryTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryType([FromRoute] byte id)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
           

            var galleryType = await context.GalleryTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (galleryType == null)return NotFound();
            context.GalleryTypes.Remove(galleryType);
            await context.SaveChangesAsync();
            return Ok(galleryType);
        }

        private bool GalleryTypeExists(int id)
        {
            return context.GalleryTypes.Any(e => e.Id == id);
        }
    }
}