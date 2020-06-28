using System.ComponentModel.DataAnnotations;

namespace DirectGharPe.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public byte ParentId { get; set; }
        
        public bool IsActive { get; set; }
    }
}