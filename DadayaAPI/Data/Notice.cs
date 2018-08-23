
namespace DadayaAPI.Data
{
    using System;

    using Microsoft.AspNetCore.Http;

    public class Notice
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Story { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
