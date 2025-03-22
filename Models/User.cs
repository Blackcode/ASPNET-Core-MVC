
using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNET_Core_MVC.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        
        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "User"; // Admin or User
        
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
