namespace subway_project.Server.Models
{
    public class Sub
    {
        public int Id { get; set; }
        public List<Topping> Toppings { get; set; } = [];
    }
}
