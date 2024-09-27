using System.ComponentModel.DataAnnotations;

namespace MultiShop.Order.Domain.Entities
{
    public class Address
    {
        [Key]
        public Guid AddressID { get; set; }
        public Guid? UserID { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
