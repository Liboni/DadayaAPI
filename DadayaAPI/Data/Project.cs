﻿
namespace DadayaAPI.Data
{
    using System;

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
