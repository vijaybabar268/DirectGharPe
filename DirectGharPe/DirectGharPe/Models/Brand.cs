using System.ComponentModel.DataAnnotations;

namespace DirectGharPe.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}