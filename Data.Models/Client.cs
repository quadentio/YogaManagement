using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Client
    {
        [Key]
        public string PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Condition { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
