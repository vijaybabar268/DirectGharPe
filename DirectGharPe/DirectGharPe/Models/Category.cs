namespace DirectGharPe.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte ParentId { get; set; }
        public bool IsActive { get; set; }
    }
}