﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroApi_net8.Entity
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        public string Occupation { get; set; }
        [Column(TypeName = "nvarchar(200)")]

        public string ImageName { get; set; }
        [NotMapped] 
        public IFormFile ImageFile { get; set;}
        [NotMapped]
        public string ImageSrc { get; set; }
    }
}
