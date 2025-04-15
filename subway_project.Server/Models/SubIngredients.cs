namespace subway_project.Server.Models
{
    public class SubIngredients
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public List<Sub> Subs { get; set; } = [];

    }
}
