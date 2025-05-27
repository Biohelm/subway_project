namespace subway_project.Server.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string ImageUrl { get; set; } = "images\\no-image-available.jpg";
        public ICollection<OrderProduct> OrderProducts { get; set; } = [];
        public double Calories { get; set; } = 0;
        public double Protein { get; set; } = 0;
        public double Carbohydrates { get; set; } = 0;
        public double Fat { get; set; } = 0;
        public double Fiber { get; set; } = 0;
        public double Salt { get; set; } = 0;
    }
}
