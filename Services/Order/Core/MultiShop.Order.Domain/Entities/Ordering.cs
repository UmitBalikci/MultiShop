using System.ComponentModel.DataAnnotations;

namespace MultiShop.Order.Domain.Entities
{
    public class Ordering
    {
        [Key]
        public Guid OrderingID { get; set; }
        public Guid? UserID { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
