using System.ComponentModel.DataAnnotations;

namespace MultiShop.Order.Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailID { get; set; }
        public Guid? ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? ProductAmount { get; set; }
        public decimal? ProductTotalPrice { get; set; }
        public Guid? OrderingID { get; set; }
        public Ordering Ordering { get; set; }
    }
}
