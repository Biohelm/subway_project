namespace subway_project.Server.Models
{
    public class Topping
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }
        public string ImageUrl { get; set; } = "images\\no-image-available.jpg";
        public List<Order> Orders { get; set; } = [];
        public List<Sub> Subs { get; set; } = [];

    }
}
