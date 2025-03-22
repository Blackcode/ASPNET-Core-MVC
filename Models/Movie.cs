
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNET_Core_MVC.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        
        [StringLength(200)]
        public string Director { get; set; }
        
        [StringLength(100)]
        public string Genre { get; set; }
        
        [Range(1900, 2100, ErrorMessage = "Release year must be between 1900 and 2100")]
        public int ReleaseYear { get; set; }
        
        [StringLength(200)]
        public string ImageUrl { get; set; }
        
        [StringLength(200)]
        public string VideoUrl { get; set; }
        
        public DateTime DateAdded { get; set; } = DateTime.Now;
        
        public bool IsFeatured { get; set; } = false;
    }
}
