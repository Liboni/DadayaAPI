﻿
namespace DadayaAPI.Data
{
    using System;
    
    public class Notice
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
