using System;

namespace DirectGharPe.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public byte? Quantity { get; set; }        
        public string Slug { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

        public Category Category { get; set; }   
        public Brand Brand { get; set; }                        
    }
}