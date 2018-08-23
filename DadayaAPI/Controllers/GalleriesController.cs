
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
    [Route("api/Galleries")]
    public class GalleriesController : Controller
    {
        private readonly ApplicationDbContext context;

        public GalleriesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Galleries
        [HttpGet]
        public IEnumerable<Gallery> GetGallery()
        {
            return context.Gallery;
        }

        // GET: api/Galleries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGallery([FromRoute] int id)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            var gallery = await context.Gallery.SingleOrDefaultAsync(m => m.Id == id);
            if (gallery == null)return NotFound();
            return Ok(gallery);
        }

        // PUT: api/Galleries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGallery([FromRoute] int id, [FromBody] GalleryModel galleryModel)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            if (id != galleryModel.Id)return BadRequest();
            var gallery = ObjectConverter.ToGallery(galleryModel).Result;
            context.Entry(ObjectConverter.ToGallery(galleryModel).Result).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
                if (gallery.MainImage)
                {
                    var galleries = context.Gallery.Where(a => a.GalleryTypeId == gallery.GalleryTypeId && a.Id!=id).ToList();
                    foreach (var gllry in galleries) { gllry.MainImage = false; }
                    context.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Galleries
        [HttpPost]
        public async Task<IActionResult> PostGallery([FromBody] GalleryModel gallery)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            if (gallery.MainImage)
            {
                var galleries = context.Gallery.Where(a => a.GalleryTypeId == gallery.GalleryTypeId).ToList();
                foreach (var gllry in galleries) { gllry.MainImage = false; }
                context.SaveChanges();
            }
            context.Gallery.Add(ObjectConverter.ToGallery(gallery).Result);
            await context.SaveChangesAsync();
            return CreatedAtAction("GetGallery", new { id = gallery.Id }, gallery);
        }

        // DELETE: api/Galleries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGallery([FromRoute] int id)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            var gallery = await context.Gallery.SingleOrDefaultAsync(m => m.Id == id);
            if (gallery == null)return NotFound();
            context.Gallery.Remove(gallery);
            await context.SaveChangesAsync();
            return Ok(gallery);
        }

        private bool GalleryExists(int id)
        {
            return context.Gallery.Any(e => e.Id == id);
        }
    }
}