
namespace DadayaAPI.Data
{
    public class Gallery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte GalleryTypeId { get; set; }
        public bool MainImage { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public virtual GalleryType GalleryType { get; set; }
    }
}
