
namespace DadayaAPI.Models
{
    using System;

    using Microsoft.AspNetCore.Http;

    public class EventModel
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public DateTime DateOfEvent { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
