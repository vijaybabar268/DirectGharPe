namespace DirectGharPe.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoThumbUrl { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
    }
}