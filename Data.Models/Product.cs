using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Product : BaseEntity
    {
        [Key]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Discount { get; set; }
        public float UnitPrice { get; set; }
    }
}
