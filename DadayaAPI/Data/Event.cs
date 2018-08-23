using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadayaAPI.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateOfEvent { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
