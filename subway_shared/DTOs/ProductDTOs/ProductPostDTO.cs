namespace subway_shared.DTOs.ProductDTOs
{
    public class ProductPostDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string ImageUrl { get; set; } = "images\\no-image-available.jpg";
        public int Calories { get; set; } = 0;
    }
}