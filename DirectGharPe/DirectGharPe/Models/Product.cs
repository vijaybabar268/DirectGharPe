using System;
using System.ComponentModel.DataAnnotations;

namespace DirectGharPe.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public string Description { get; set; }
                
        public decimal? PriceBefore { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Price { get; set; }

        public decimal? Save { get; set; }

        public byte? Quantity { get; set; }        
        
        public string Slug { get; set; }
        
        public bool IsActive { get; set; }
        
        public DateTime? DateAdded { get; set; }
        
        public DateTime? DateModified { get; set; }

        public Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        public Brand Brand { get; set; }
        
        [Required]
        public int BrandId { get; set; }

        public Photo Photo { get; set; }

        public int? PhotoId { get; set; }
    }
}