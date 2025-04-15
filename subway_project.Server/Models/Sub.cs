namespace subway_project.Server.Models
{
    public class Sub
    {
        public int Id { get; set; }
        public List<SubIngredients> SubIngredients { get; set; } = [];
    }
}
