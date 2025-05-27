using subway_shared.DTOs.ProductDTOs;
using subway_shared.DTOs.SubDTOs;

namespace subway_shared.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public bool TakeAway { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductDTO> Products { get; set; } = new();
        public List<SubDTO> Subs { get; set; } = new();
        public string customerId { get; set; } = null!;
        public double TotalCalories { get; set; }
    }
}