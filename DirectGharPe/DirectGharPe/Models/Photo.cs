using System.ComponentModel.DataAnnotations;

namespace DirectGharPe.Models
{
    public class Photo
    {
        public int Id { get; set; }
        
        [Required]
        public string PhotoUrl { get; set; }
        
        [Required]
        public string PhotoThumbUrl { get; set; }
        
        public bool IsDefault { get; set; }
        
        public bool IsActive { get; set; }
        
        [Required]
        public int ProductId { get; set; }    
    }
}