namespace DirectGharPe.ViewModels
{
    public class ProductPhotoFormViewModel
    {
        public int Id { get; set; }
                
        public string PhotoUrl { get; set; }

        public string PhotoThumbUrl { get; set; }

        public bool IsActive { get; set; }

        public int ProductId { get; set; }
    }
}