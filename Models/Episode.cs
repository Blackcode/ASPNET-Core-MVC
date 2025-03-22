
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNET_Core_MVC.Models
{
    public class Episode
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        [Range(1, 100, ErrorMessage = "Season number must be between 1 and 100")]
        public int SeasonNumber { get; set; }
        
        [Range(1, 1000, ErrorMessage = "Episode number must be between 1 and 1000")]
        public int EpisodeNumber { get; set; }
        
        [StringLength(200)]
        public string VideoUrl { get; set; }
        
        public DateTime DateAdded { get; set; } = DateTime.Now;
        
        // Duration in minutes
        public int Duration { get; set; }
        
        // Foreign key
        public int TvSeriesId { get; set; }
        
        // Navigation property
        public TvSeries TvSeries { get; set; }
    }
}
