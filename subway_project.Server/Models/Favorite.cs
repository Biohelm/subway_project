namespace subway_project.Server.Models;

public class Favorite
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
}