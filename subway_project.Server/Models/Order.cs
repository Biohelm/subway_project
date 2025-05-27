namespace subway_project.Server.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool TakeAway { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = [];
        public List<Sub> Subs { get; set; } = new();
        public DateTime OrderReceived { get; set; } = DateTime.Now;
        public DateTime? OrderInProgress { get; set; }
        public DateTime? OrderCompleted { get; set; }
        public DateTime? OrderCollected { get; set; }
        public string CustomerId { get; set; } = null!;
        public double TotalCalories { get; set; }
    }
}
