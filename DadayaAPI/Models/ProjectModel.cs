
namespace DadayaAPI.Models
{
    using System;

    using Microsoft.AspNetCore.Http;

    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IFormFile Image { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
