namespace subway_project.Server.Models
{
    public class Queue
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

    }
}
