namespace subway_project.Server.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool TakeAway { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Product> Products { get; set; } = [];
        public List<Sub> Subs { get; set; } = [];
        public DateTime OrderReceived { get; set; } = DateTime.Now;
        public DateTime? OrderInProgress { get; set; }
        public DateTime? OrderCompleted { get; set; }
        public DateTime? OrderCollected { get; set; }
        public Queue Queue { get; set; } = null!;
    }
}
