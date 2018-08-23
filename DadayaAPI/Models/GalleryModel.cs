
namespace DadayaAPI.Models
{
    using Microsoft.AspNetCore.Http;

    public class GalleryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte GalleryTypeId { get; set; }
        public bool MainImage { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
    }
}
