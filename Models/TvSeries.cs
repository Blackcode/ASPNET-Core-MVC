
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNET_Core_MVC.Models
{
    public class TvSeries
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        
        [StringLength(200)]
        public string Creator { get; set; }
        
        [StringLength(100)]
        public string Genre { get; set; }
        
        public int StartYear { get; set; }
        
        public int? EndYear { get; set; }
        
        [StringLength(200)]
        public string ImageUrl { get; set; }
        
        public DateTime DateAdded { get; set; } = DateTime.Now;
        
        public bool IsFeatured { get; set; } = false;
        
        // Navigation property
        public ICollection<Episode> Episodes { get; set; }
    }
}
